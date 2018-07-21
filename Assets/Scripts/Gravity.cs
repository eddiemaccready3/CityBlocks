using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
   [SerializeField] private float gravityModifier = 1f;

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float timeElapsed;

    public bool isGrounded = false;


    private Vector2 startPosition;
    private Vector2 currentPosition;
    private float xPosition;
    private float yPosition;
    private Rigidbody2D blockRigidBody;

    void Start()
    {
        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
    }


    private void Update()
    {
        //CheckCollisionBeforeMovement();
        if (!isGrounded)
        {
            MoveDown();
        }
    }


    private void MoveDown()
    {
        yPosition = transform.position.y;
        yMovementEachFrame = yPosition + (gravityAcceleration * Time.deltaTime * timeElapsed * gravityModifier);
        transform.position = new Vector2(xPosition, yMovementEachFrame);
        timeElapsed += Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D other)
        {
            if (other.tag != "Spawner")
            {
                isGrounded = true;
                transform.position = new Vector2(xPosition, Mathf.Round(yPosition));
            }

            else
            {
                isGrounded = false;
            }
        }
}
