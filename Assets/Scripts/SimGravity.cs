using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimGravity : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float gravityModifier = 1f;
    //[SerializeField] GameObject blockOfNewColor;

    PauseGameStatus pauseGameStatusScript;

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

    public bool isGrounded = false;
    
    private Vector2 currentPosition;
    private Vector3 newPositionBlockOfNewColor = new Vector3(-3, 4, 0);
    private Vector2 collisionSpot = new Vector2(0, 4.25f);

    Scene m_Scene;

    private string sceneName;

    void Start()
    {
        pauseGameStatusScript = FindObjectOfType<PauseGameStatus>();

        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        m_Scene = SceneManager.GetActiveScene();
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        print("pauseGameStatusScript.pauseManual: " + pauseGameStatusScript.pauseManual);
        if(pauseGameStatusScript.pauseManual == false)
        {
            CheckForCollisions();
            MoveOrGround();
        }
    }

    private void MoveOrGround()
    {
        if (!isGrounded)
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
        //if (hitColliders.Length > 0)
        //{
        //    print("hitColldersLength before " + hitColliders[0]);
        //}
        if (hitColliders.Length < 1)
        {
            isGrounded = false;
        }

        else if (hitColliders.Length > 0)
        {
            if (hitColliders[0] == null)
            {
                isGrounded = false;
            }
        }

        Array.Clear(hitColliders, 0, hitColliders.Length);
        //if (hitColliders.Length > 0)
        //{
        //    print("hitColldersLength after " + hitColliders[0]);
        //}

        //else
        //{
        //    isGrounded = false;
        //}
    }

    private void MoveDown()
    {
        yPosition = transform.position.y;
        //print(this.gameObject.name + " yPos " + yPosition);
        moveDistance = gravityAcceleration * Time.deltaTime * timeElapsed * gravityModifier;
            
        CheckForCollisions();

        if (hitColliders.Length > 0 && (yPosition - Math.Floor(yPosition)) < Math.Abs(moveDistance))
        {
            isGrounded = true;
        }
            
        else
        {
            yMovementEachFrame = yPosition + moveDistance;
            transform.position = new Vector2(xPosition, yMovementEachFrame);
            timeElapsed += Time.deltaTime;
            isGrounded = false;
        }
    }

    private void GroundBlock()
    {
        isGrounded = true;
        this.transform.position = new Vector2(xPosition, Mathf.Floor(yPosition));
            
        timeElapsed = 0f;
    }
}