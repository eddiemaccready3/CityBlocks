using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class PlaneMovementStatic : MonoBehaviour
{
    //Distance variables:
    [SerializeField] private float distanceToScaleUp;

    private float xDistanceMarkerToMarker;
    private float yDistanceMarkerToMarker;
    private float distanceMarkerToMarker;
    private float distanceStartToCurrent;
    public float distanceCurrentToEnd;
    public float distanceCurrentToScaleDownEnd;
    public float xPerFrameMoveDistance;
    private float yPerFrameMoveDistance;
    private float straightPerFrameMoveDistance;

    //Position variables:
    private float scaleDownEndXPos;
    private float scaleDownEndYPos;
    private float previousMarkerYPos;
    private float thisMarkerXPos;
    private float thisMarkerYPos;
    private float previousMarkerXPos;
    private float currentXPosition;
    private float currentYPosition;
    private float newXPosEachFrame;
    private float newYPosEachFrame;

    private int xMoveDirection;
    private int yMoveDirection;

    public bool moveCamera;
    private bool startToScaleDown = false;

    //Scale variables:
    [SerializeField] private float fullScale;

    private float startingScale;
    private float scaleFactorPerFrame;

    //Speed variables:
    private float speedModifier;
    private float acceleration = 10f;

    //Reference scripts:
    private MarkerAvailability availabilityScript;
    private PauseGameStatus pauseGameScript;

    //Reference GameObjects
    private GameObject endMarker;

    //Time variables
    private float startTime;
    [SerializeField] private float timeToScaleUp;

    // Use this for initialization
	void Start()
    {
        PauseGame();

        startTime = Time.time;

        endMarker = GameObject.Find("BangkokMarker");

        scaleDownEndXPos = endMarker.transform.position.x;
        scaleDownEndYPos = endMarker.transform.position.y;
        
        GameObject thisCityMarker = GameObject.Find(PlayerPrefs.GetString("thisCityName") + "Marker");
        availabilityScript = thisCityMarker.GetComponent<MarkerAvailability>();

        if (availabilityScript.thisContinent != availabilityScript.previousContinent)
        {
            moveCamera = true;
        }
        else
        {
            moveCamera = false;
        }

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
        scaleDownEndXPos = endMarker.transform.position.x;
        scaleDownEndYPos = endMarker.transform.position.y;

        distanceStartToCurrent = CalcFlightDistances(previousMarkerXPos, currentXPosition, previousMarkerYPos, currentYPosition);
        distanceCurrentToEnd = CalcFlightDistances(currentXPosition, thisMarkerXPos, currentYPosition, thisMarkerYPos);
        distanceCurrentToScaleDownEnd = CalcFlightDistances(currentXPosition, scaleDownEndXPos, currentYPosition, scaleDownEndYPos);
    }

    private float CalcFlightDistances(float startXPos, float endXPos, float startYPos, float endYPos)
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;

        float xDistStartToEnd = TrigFunctions.FindDistance(startXPos, endXPos);
        float yDistStartToEnd = TrigFunctions.FindDistance(startYPos, endYPos);
        return TrigFunctions.PythagoreanTheorem(xDistStartToEnd, yDistStartToEnd);
    }

    private void MoveGameObject()
    {
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;

        xMoveDirection = SetMoveDirection(previousMarkerXPos, thisMarkerXPos);
        yMoveDirection = SetMoveDirection(previousMarkerYPos, thisMarkerYPos);

        xDistanceMarkerToMarker = TrigFunctions.FindDistance(previousMarkerXPos, thisMarkerXPos);
        yDistanceMarkerToMarker = TrigFunctions.FindDistance(previousMarkerYPos, thisMarkerYPos);

        xPerFrameMoveDistance = CalcAxisMoveDistance(xDistanceMarkerToMarker, xMoveDirection);
        yPerFrameMoveDistance = CalcAxisMoveDistance(yDistanceMarkerToMarker, yMoveDirection);

        straightPerFrameMoveDistance = TrigFunctions.PythagoreanTheorem(xPerFrameMoveDistance, yPerFrameMoveDistance);

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
        pauseGameScript.pauseAuto = false;
    }

    private void InvokeDestroy()
    {
        Destroy(gameObject);
    }

    private void SetGameObjectScale()
    {
        if ((Time.time - startTime) < timeToScaleUp)  // distanceStartToCurrent < distanceToScaleUp)
        {
            transform.localScale += new Vector3(scaleFactorPerFrame, scaleFactorPerFrame, 0f);
        }

        else if (distanceCurrentToScaleDownEnd < distanceToScaleUp)
        {
            startToScaleDown = true;
            transform.localScale -= new Vector3(scaleFactorPerFrame, scaleFactorPerFrame, 0f);
        }

        if (transform.localScale.x >= fullScale && startToScaleDown == false)
        {
            transform.localScale = new Vector3(fullScale, fullScale, 1f);
        }

        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
    }
}