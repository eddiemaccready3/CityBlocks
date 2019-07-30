using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsMovement : MonoBehaviour {

	[SerializeField] private float slowSpeed;
    [SerializeField] private float fastSpeed;
    [SerializeField] private float yTextPosition = 9.83f;

    private Counter counterScript;

    private Renderer rend;
    
    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float timeElapsed = 0;
    private float xMoveDistance;
    private float yMoveDistance;
    private float currentXPosition;
    private float currentYPosition;
    private float startXPosition;
    private float startYPosition;

    // Use this for initialization
	void Start()
    {
        startXPosition = transform.position.x;
        startYPosition = transform.position.y;
        counterScript = FindObjectOfType<Counter>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
	
    private void FixedUpdate()
    {
        //print("Time elapsed " + timeElapsed);
        if(timeElapsed < 1.5f)
        {
            MoveSlow();
        }

        else
        {
            MoveFast();
        }

        timeElapsed += Time.deltaTime;
    }

    private void MoveSlow()
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;
        xMoveDistance = (5.88f - startXPosition) / (slowSpeed);
        yMoveDistance = (yTextPosition - startYPosition) / (slowSpeed);
        xMovementEachFrame = currentXPosition + xMoveDistance;
        yMovementEachFrame = currentYPosition + yMoveDistance;
        transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
    }

    private void MoveFast()
    {
        xMoveDistance = (5.88f - currentXPosition) / (fastSpeed);
        yMoveDistance = (yTextPosition - currentYPosition) / (fastSpeed);
        xMovementEachFrame = transform.position.x + xMoveDistance;
        yMovementEachFrame = transform.position.y + yMoveDistance;
        transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
        if(transform.localScale.x > 0.25f)
        {
            transform.localScale -= new Vector3(0.01F, 0.01f, 0f);
        }
        
        if(transform.position.y > yTextPosition)
        {
            counterScript.startAddingScore = true;
            rend.enabled = false;
            counterScript.scoreBalanceText.fontStyle = FontStyle.Bold;
            counterScript.scoreBalanceText.fontSize = 350;
            Invoke("InvokeDestroy", 0.15f);
        }
    }

    private void InvokeDestroy()
    {
        counterScript.scoreBalanceText.fontStyle = FontStyle.Normal;
        counterScript.scoreBalanceText.fontSize = 300;
        Destroy(gameObject);
    }
}
