﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    //Distance variables:
    [SerializeField] private float distanceToScaleUp;

    private float xDistanceMarkerToMarker;
    private float yDistanceMarkerToMarker;
    private float distanceMarkerToMarker;
    private float distanceStartToCurrent;
    private float distanceCurrentToEnd;
    private float xPerFrameMoveDistance;
    private float yPerFrameMoveDistance;
    private float straightPerFrameMoveDistance;

    //Position variables:
    private float previousMarkerXPos;
    private float previousMarkerYPos;
    private float thisMarkerXPos;
    private float thisMarkerYPos;
    private float currentXPosition;
    private float currentYPosition;
    private float newXPosEachFrame;
    private float newYPosEachFrame;

    private int xMoveDirection;
    private int yMoveDirection;

    //Scale variables:
    [SerializeField] private float fullScale;

    private float startingScale;
    private float scaleFactorPerFrame;

    //Speed variables:
    private float speedModifier;

    private float acceleration = 10f;

    //Reference scripts:
    private Availability availabilityScript;
    private PauseGameStatus pauseGameScript;

    // Use this for initialization
	void Start()
    {
        PauseGame();
        
        GameObject thisCityMarker = GameObject.Find(PlayerPrefs.GetString("thisCityName") + "Marker");
        availabilityScript = thisCityMarker.GetComponent<Availability>();

        startingScale = transform.localScale.x;

        previousMarkerXPos = availabilityScript.previousMarkerPos.x;
        previousMarkerYPos = availabilityScript.previousMarkerPos.y;
        thisMarkerXPos = availabilityScript.thisMarkerPos.x;
        thisMarkerYPos = availabilityScript.thisMarkerPos.y;

        distanceMarkerToMarker = CalcFlightDistances(previousMarkerXPos, thisMarkerXPos, previousMarkerYPos, thisMarkerYPos);

        if(distanceMarkerToMarker < 300f)
        {
            speedModifier = 6f;
        }

        else
        {
            speedModifier = 12f;
        }

        print("distanceMarkerToMarker:" + distanceMarkerToMarker);

        //if(distanceMarkerToMarker)
    }

    private void PauseGame()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        pauseGameScript.pauseAuto = true;
    }

    private void FixedUpdate()
    {
        SetFlightDistances();
        MoveGameObject();
    }

    private void SetFlightDistances()
    {
        distanceStartToCurrent = CalcFlightDistances(previousMarkerXPos, currentXPosition, previousMarkerYPos, currentYPosition);
        distanceCurrentToEnd = CalcFlightDistances(currentXPosition, thisMarkerXPos, currentYPosition, thisMarkerYPos);
    }

    private float CalcFlightDistances(float startXPos, float endXPos, float startYPos, float endYPos)
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;

        float xDistStartToEnd = FindDistance(startXPos, endXPos);
        float yDistStartToEnd = FindDistance(startYPos, endYPos);
        return PythagoreanTheorem(xDistStartToEnd, yDistStartToEnd);
    }

    private float FindDistance(float start, float end)
    {
        return Mathf.Abs(start - end);
    }

    private float PythagoreanTheorem(float a, float b)
    {
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        return c;
    }

    private void MoveGameObject()
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;

        xMoveDirection = SetMoveDirection(previousMarkerXPos, thisMarkerXPos);
        yMoveDirection = SetMoveDirection(previousMarkerYPos, thisMarkerYPos);

        xDistanceMarkerToMarker = FindDistance(previousMarkerXPos, thisMarkerXPos);
        yDistanceMarkerToMarker = FindDistance(previousMarkerYPos, thisMarkerYPos);

        xPerFrameMoveDistance = CalcAxisMoveDistance(xDistanceMarkerToMarker, xMoveDirection);
        yPerFrameMoveDistance = CalcAxisMoveDistance(yDistanceMarkerToMarker, yMoveDirection);

        straightPerFrameMoveDistance = PythagoreanTheorem(xPerFrameMoveDistance, yPerFrameMoveDistance);

        scaleFactorPerFrame = (fullScale - startingScale) / (distanceToScaleUp / straightPerFrameMoveDistance);

        newXPosEachFrame = currentXPosition + xPerFrameMoveDistance;
        newYPosEachFrame = currentYPosition + yPerFrameMoveDistance;

        SetGameObjectPosAndStat();

        SetGameObjectScale();
    }

    private int SetMoveDirection(float previousMarkerPos, float thisMarkerPos)
    {
        if(previousMarkerPos > thisMarkerPos)
        {
            return -1;
        }

        else
        {
            return 1;
        }
    }

    private float CalcAxisMoveDistance(float totalAxisDistance, float moveDirection)
    {
        if(totalAxisDistance > 0)
        {
            return ((((totalAxisDistance * acceleration) / distanceMarkerToMarker) * speedModifier) * moveDirection) * Time.deltaTime;
        }

        else
        {
            return 0;
        }
    }

    private void SetGameObjectPosAndStat()
    {
        if (
                    (xMoveDirection < 0 && currentXPosition > thisMarkerXPos) ||
                    (xMoveDirection > 0 && currentXPosition < thisMarkerXPos) ||
                    (yMoveDirection < 0 && currentYPosition > thisMarkerYPos) ||
                    (yMoveDirection > 0 && currentYPosition < thisMarkerYPos)
                    )

        {
            transform.position = new Vector2(newXPosEachFrame, newYPosEachFrame);
        }

        else
        {
            UnpauseGame();
            Invoke("InvokeDestroy", 0.15f);
        }
    }

    private void UnpauseGame()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        pauseGameScript.pauseAuto = true;
    }

    private void InvokeDestroy()
    {
        Destroy(gameObject);
    }

    private void SetGameObjectScale()
    {
        if (distanceStartToCurrent < distanceToScaleUp)
        {
            transform.localScale += new Vector3(scaleFactorPerFrame, scaleFactorPerFrame, 0f);
        }

        else if (distanceCurrentToEnd < distanceToScaleUp)
        {
            transform.localScale -= new Vector3(scaleFactorPerFrame, scaleFactorPerFrame, 0f);
        }

        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        }
    }
}
