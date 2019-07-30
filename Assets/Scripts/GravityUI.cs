using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityUI : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    public float gravityModifier;

    private Collider2D [] hitColliders;
    private int qtyCollidersHit;

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private int blockFallCounter;
    private int qtyCollidersHitCounter;
    private Vector2 overlapBoxPosition;
    private Vector2 overlapBoxSize;

    public bool isGroundedUI = false;
    
    private Vector2 currentPosition;
    private Vector3 newPositionBlockOfNewColor = new Vector3(-3, 4, 0);
    private Vector2 collisionSpot = new Vector2(0, 4.25f);

    Scene m_Scene;

    private string sceneName;

    void Start()
    {
        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        m_Scene = SceneManager.GetActiveScene();
        isGroundedUI = false;
    }

    private void FixedUpdate()
    {
        CheckForCollisions();
        MoveOrGround();
    }

    private void MoveOrGround()
    {
        if (!isGroundedUI)
        {
            MoveDown();
        }
        
        else
        {
            GroundBlock();
        }
    }

    private void CheckForCollisions()
    {
        overlapBoxPosition = new Vector2(transform.position.x, transform.position.y - 0.85f);
        overlapBoxSize = new Vector2(0.25f, 0.85f);
        hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0, layerMask);
        qtyCollidersHit = hitColliders.Length;
        
        if (hitColliders.Length < 1)
        {
            isGroundedUI = false;
        }

        else if (hitColliders.Length > 0)
        {
            if (hitColliders[0] == null)
            {
                isGroundedUI = false;
            }
        }

        Array.Clear(hitColliders, 0, hitColliders.Length);
    }

    private void MoveDown()
    {
        yPosition = transform.position.y;
        moveDistance = gravityAcceleration * Time.deltaTime * timeElapsed * gravityModifier;
            
        CheckForCollisions();

        if (hitColliders.Length > 0 && (yPosition - Math.Floor(yPosition)) < Math.Abs(moveDistance))
        {
            isGroundedUI = true;
        }
            
        else
        {
            yMovementEachFrame = yPosition + moveDistance;
            transform.position = new Vector2(xPosition, yMovementEachFrame);
            timeElapsed += Time.deltaTime;
            isGroundedUI = false;
        }
    }

    private void GroundBlock()
    {
        isGroundedUI = true;
            
        this.transform.position = new Vector2(xPosition, Mathf.Floor(yPosition));
            
        timeElapsed = 0f;
    }
}