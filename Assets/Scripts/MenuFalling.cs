using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFalling : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private float yMoveFactor = 0f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float stopYPosition = 5.5f;

    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private bool grounded = false;

    private void FixedUpdate()
    {
        if(grounded == false)
        {
            Move();
        }
    }

    private void Move()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        moveDistance = acceleration * Time.deltaTime * speedModifier;
        yMovementEachFrame = yPosition - (moveDistance * yMoveFactor);
        
        if(yPosition >= stopYPosition)
        {
            
            transform.position = new Vector2(xPosition, yMovementEachFrame);
        }

        else
        {
            grounded = true;
        }
    }
}
