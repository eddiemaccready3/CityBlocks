using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTextMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] public float moveDelay;
    [SerializeField] private float xEndPosition;
    [SerializeField] private float xEndPosLeftJustify;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float minScale;
    [SerializeField] private Text thisText;
    [SerializeField] private Canvas thisCanvas;

    float yEndPosition;
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
        yEndPosition = GameObject.Find("Score").transform.position.y;
        
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
        yEndPosition = GameObject.Find("Score").transform.position.y;
        if(timeElapsed > moveDelay && moveComplete == false)
        {
            Move();
        }

        if(moveComplete == true)
        {
            transform.position = new Vector3(xEndPosLeftJustify, yEndPosition, 0f);
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
        
        if (transform.localScale.x > 0.3f)
        {
            transform.localScale -= new Vector3(0.005F, 0.005f, 0f);
        }

        if (transform.position.y > yEndPosition)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0f);
            thisText.alignment = TextAnchor.MiddleLeft;
            transform.position = new Vector3(xEndPosLeftJustify, yEndPosition, 0f);

            moveComplete = true;

           //print("Running...");
        }
    }
}
