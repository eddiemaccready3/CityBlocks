using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinsMovement : MonoBehaviour
{
    [SerializeField] private float slowSpeed;
    [SerializeField] private float fastSpeed;
    [SerializeField] private float yTextPosition = 9.83f;
    private GameObject objectToFlyTo;

    private Counter counterScript;

    private int fontSize;

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

    [SerializeField] private bool startCoinMovement;

    // Use this for initialization
	void Start()
    {
        startXPosition = transform.position.x;
        startYPosition = transform.position.y;
        counterScript = FindObjectOfType<Counter>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        fontSize = counterScript.scoreBalanceText.fontSize;

        objectToFlyTo = GameObject.Find("ShuffleButton");
    }
	
    private void FixedUpdate()
    {
        yTextPosition = objectToFlyTo.transform.position.y;
        if(startCoinMovement == true)
        {
            if (timeElapsed < 0.25f)
            {
                MoveSlow();
            }

            else
            {
                MoveFast();
            }
        }

        timeElapsed += Time.deltaTime;
    }

    private void MoveSlow()
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;
        xMoveDistance = (0.67f - startXPosition) / (slowSpeed);
        yMoveDistance = (yTextPosition - startYPosition) / (slowSpeed);
        xMovementEachFrame = currentXPosition + xMoveDistance;
        yMovementEachFrame = currentYPosition + yMoveDistance;
        transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
    }

    private void MoveFast()
    {
        xMoveDistance = (0.67f - currentXPosition) / (fastSpeed);
        yMoveDistance = (yTextPosition - currentYPosition) / (fastSpeed);
        xMovementEachFrame = transform.position.x + xMoveDistance;
        yMovementEachFrame = transform.position.y + yMoveDistance;
        transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
        if (transform.localScale.x > 0.25f)
        {
            transform.localScale -= new Vector3(0.01F, 0.01f, 0f);
        }

        if (transform.position.y > yTextPosition)
        {
            counterScript.startAddingCoins = true;
            rend.enabled = false;
            counterScript.coinsBalanceText.fontStyle = FontStyle.Bold;
            counterScript.coinsBalanceText.fontSize = (int)Math.Round(fontSize * 1.167);
            Invoke("InvokeDestroy", 0.15f);
        }
    }

    private void InvokeDestroy()
    {
        counterScript.coinsBalanceText.fontStyle = FontStyle.Normal;
        counterScript.coinsBalanceText.fontSize = fontSize;
        Destroy(gameObject);
    }
}
