using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDelay;
    
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float minScale;
    [SerializeField] private float xMinMoveDistance;
    
    private float xEndPosition;
    private float yEndPosition;
    private float xPosEachFrame;
    private float yPosEachFrame;
    private float timeElapsed = 0;
    private float xMoveDistance;
    private float yMoveDistance;
    private float yMinMoveDistance;
    private float currentXPosition;
    private float currentYPosition;
    private float startXPosition;
    private float startYPosition;
    private float scaleFactor;

    private GameObject smallShapeObject;
    private string smallShapeObjectName;

    // Use this for initialization
	void Start()
    {
        smallShapeObjectName = transform.gameObject.name;
        smallShapeObjectName = smallShapeObjectName.Replace("(Clone)", "");
        smallShapeObjectName = smallShapeObjectName.Remove(0,6);
        smallShapeObject = GameObject.Find("Small" + smallShapeObjectName);
        xEndPosition = smallShapeObject.transform.position.x;
        yEndPosition = smallShapeObject.transform.position.y;
        
        startXPosition = transform.position.x;
        startYPosition = transform.position.y;

        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;

        xMoveDistance = (xEndPosition - currentXPosition) / moveSpeed;
        yMoveDistance = (yEndPosition - currentYPosition) / moveSpeed;

        scaleFactor = Mathf.Abs(xEndPosition - currentXPosition);

        yMinMoveDistance = Mathf.Abs((yMoveDistance * xMinMoveDistance) / xMoveDistance);
    }
	
    private void FixedUpdate()
    {
        if(timeElapsed > moveDelay)
        {
            Move();
        }

        timeElapsed += Time.deltaTime;
    }

    private void Move()
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;
        
        if(Mathf.Abs(xMoveDistance) < Mathf.Abs(xMinMoveDistance))
        {
            xPosEachFrame = transform.position.x + ((xMoveDistance/Mathf.Abs(xMoveDistance)) * xMinMoveDistance);
            yPosEachFrame = transform.position.y + ((yMoveDistance/Mathf.Abs(yMoveDistance)) * yMinMoveDistance);

            transform.position = new Vector2(xPosEachFrame, yPosEachFrame);
        }

        else
        {
            xMoveDistance = (xEndPosition - currentXPosition) / moveSpeed;
            yMoveDistance = (yEndPosition - currentYPosition) / moveSpeed;
            xPosEachFrame = transform.position.x + ((xMoveDistance/Mathf.Abs(xMoveDistance)) * xMinMoveDistance);
            yPosEachFrame = transform.position.y + ((yMoveDistance/Mathf.Abs(yMoveDistance)) * yMinMoveDistance);

            transform.position = new Vector2(xPosEachFrame, yPosEachFrame);
        }
        
        if (transform.localScale.x > minScale)
        {
            transform.localScale -= new Vector3(scaleSpeed / scaleFactor, scaleSpeed / scaleFactor, 0f);
        }

        if (transform.localScale.x < minScale)
        {
            transform.localScale = new Vector3(minScale, minScale, 0f);
        }
    }
}
