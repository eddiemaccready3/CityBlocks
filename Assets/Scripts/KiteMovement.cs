using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteMovement : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;

    [SerializeField] private float moveFactor = 0f;
    [SerializeField] private float minMoveFactor = 0f;
    [SerializeField] private float maxMoveFactor = 0f;

    [SerializeField] private float xAccelerationMin = 1f;
    [SerializeField] private float xAccelerationMax = 3f;

    [SerializeField] private float yAccelerationMin = 1f;
    [SerializeField] private float yAccelerationMax = 3f;

    [SerializeField] private float moveTimeFactor = 3f;
    [SerializeField] private float minMoveTimeFactor = 0f;
    [SerializeField] private float maxMoveTimeFactor = 3f;

    private float xAcceleration;
    private float yAcceleration;
    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float xMoveDistance;
    private float yMoveDistance;
    private float xPosition;
    private float yPosition;
    private Vector2 currentPosition;
    private float startTime;
    private float currentTime;

    // Use this for initialization
	void Start()
    {
        currentPosition = transform.position;
        xPosition = transform.position.x;
        yPosition = transform.position.y;

        startTime = Time.time;
        xAcceleration = Random.Range (xAccelerationMin, xAccelerationMax);
        yAcceleration = Random.Range (yAccelerationMin, yAccelerationMax);
        moveFactor = Random.Range (minMoveFactor, maxMoveFactor);
        moveTimeFactor = Random.Range (minMoveTimeFactor, maxMoveTimeFactor);
    }
	
    private void FixedUpdate()
    {
        currentTime = Time.time;
        Move();
        if(currentTime - startTime > moveTimeFactor)
        {
            startTime = Time.time;
            xAcceleration = Random.Range (xAccelerationMin, xAccelerationMax);
            yAcceleration = Random.Range (yAccelerationMin, yAccelerationMax);
            //moveFactor = Random.Range (minYMoveFactor, maxYMoveFactor);
            moveTimeFactor = Random.Range (minMoveTimeFactor, maxMoveTimeFactor);
        }
    }

    private void Move()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        xMoveDistance = xAcceleration * Time.deltaTime * speedModifier * moveFactor;
        yMoveDistance = yAcceleration * Time.deltaTime * speedModifier;// * moveFactor;
        xMovementEachFrame = xPosition + xMoveDistance;
        yMovementEachFrame = yPosition + yMoveDistance;
        transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
    }
}
