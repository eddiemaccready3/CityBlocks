using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTextMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDelay;
    [SerializeField] private float xEndPosition;
    [SerializeField] private float yEndPosition;
    
    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float timeElapsed = 0;
    private float xMoveDistance;
    private float yMoveDistance;
    private float xMinMoveDistance;
    private float yMinMoveDistance;
    private float currentXPosition;
    private float currentYPosition;
    private float startXPosition;
    private float startYPosition;

    private bool moveComplete = false;

    // Use this for initialization
	void Start()
    {
        startXPosition = transform.position.x;
        startYPosition = transform.position.y;

        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;

        xMoveDistance = (xEndPosition - currentXPosition) / moveSpeed;
        yMoveDistance = (yEndPosition - currentYPosition) / moveSpeed;

        xMinMoveDistance = 0.03f;
        yMinMoveDistance = (yMoveDistance * xMinMoveDistance) / (-xMoveDistance);
    }
	
    private void FixedUpdate()
    {
        if(timeElapsed > moveDelay && moveComplete == false)
        {
            Move();
        }

        timeElapsed += Time.deltaTime;
    }

    private void Move()
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;
        
        if(Mathf.Abs(xMoveDistance) < 0.03f)
        {
            xMovementEachFrame = transform.position.x - xMinMoveDistance;
            yMovementEachFrame = transform.position.y + yMinMoveDistance;

            transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
        }

        else
        {
            xMoveDistance = (xEndPosition - currentXPosition) / moveSpeed;
            yMoveDistance = (yEndPosition - currentYPosition) / moveSpeed;
            xMovementEachFrame = transform.position.x + xMoveDistance;
            yMovementEachFrame = transform.position.y + yMoveDistance;

            transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
        }
        
        if (transform.localScale.x > 0.25f)
        {
            transform.localScale -= new Vector3(0.005F, 0.005f, 0f);
        }

        if (transform.position.y > yEndPosition)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0f);

            transform.position = new Vector2(xEndPosition, yEndPosition)
        }
    }
    
    
    
    
 //   [SerializeField] private float moveSpeed;
 //   [SerializeField] private float yEndPosition;
 //   [SerializeField] private float moveDelay;
 //   [SerializeField] private float xEndPosition;
    
 //   private float xMovementEachFrame;
 //   private float yMovementEachFrame;
 //   private float timeElapsed = 0;
 //   private float xMoveDistance;
 //   private float yMoveDistance;
 //   private float xMinMoveDistance;
 //   private float yMinMoveDistance;
 //   private float currentXPosition;
 //   private float currentYPosition;
 //   private float startXPosition;
 //   private float startYPosition;

 //   // Use this for initialization
	//void Start()
 //   {
 //       startXPosition = transform.position.x;
 //       startYPosition = transform.position.y;

 //       currentXPosition = transform.position.x;
 //       currentYPosition = transform.position.y;

 //       xMoveDistance = (xEndPosition - currentXPosition) / moveSpeed;
 //       yMoveDistance = (yEndPosition - currentYPosition) / moveSpeed;

 //       xMinMoveDistance = 0.03f;
 //       yMinMoveDistance = (yMoveDistance * xMinMoveDistance) / (-xMoveDistance);
 //   }
	
 //   private void FixedUpdate()
 //   {
 //       if(timeElapsed > moveDelay)
 //       {
 //           Move();
 //       }

 //       timeElapsed += Time.deltaTime;
 //   }

 //   private void Move()
 //   {
 //       currentXPosition = transform.position.x;
 //       currentYPosition = transform.position.y;
        
 //       if(Mathf.Abs(xMoveDistance) < 0.03f)
 //       {
 //           xMovementEachFrame = transform.position.x - xMinMoveDistance;
 //           yMovementEachFrame = transform.position.y + yMinMoveDistance;

 //           transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
 //       }

 //       else
 //       {
 //           xMoveDistance = (xEndPosition - currentXPosition) / moveSpeed;
 //           yMoveDistance = (yEndPosition - currentYPosition) / moveSpeed;
 //           xMovementEachFrame = transform.position.x + xMoveDistance;
 //           yMovementEachFrame = transform.position.y + yMoveDistance;

 //           transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
 //       }
        
 //       if (transform.localScale.x > 0.25f)
 //       {
 //           transform.localScale -= new Vector3(0.005F, 0.005f, 0f);
 //       }

 //       if (transform.position.y > yEndPosition)
 //       {
 //           Destroy(gameObject);
 //       }
 //   }
}
