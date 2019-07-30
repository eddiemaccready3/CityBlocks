using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private float distanceToScaleUp;

    private float angle;
    private float xDistance;
    private float yDistance;
    private float distanceMarkerToMarker;
    private float distanceStartToCurrent;
    private float distanceCurrentToEnd;
    private float acceleration = 10f;
    private float xMoveDistance;
    private float yMoveDistance;
    private float straightMoveDistance;
    private float scaleFactor;

    private int xMoveDirectionPosNeg;
    private int yMoveDirectionPosNeg;
    private float xPosition;
    private float yPosition;
    private Vector2 currentPosition;

    private Availability availabilityScript;

    // Use this for initialization
	void Start()
    {
        //distanceToScaleUp *= acceleration;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        acceleration = 10f;

        GameObject thisCityMarker = GameObject.Find(PlayerPrefs.GetString("thisCityName") + "Marker");
        availabilityScript = thisCityMarker.GetComponent<Availability>();

        FindFlightDistances();
    }

    private void FixedUpdate()
    {
        FindDistanceFromStart();
        FindDistanceToEnd();
        Move();
    }

    private float PythagoreanTheorem(float a, float b)
    {
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        return c;
    }

    private float FindXDistance(float xStart, float xEnd)
    {
        return Mathf.Abs(xStart - xEnd);
    }

    private float FindYDistance(float yStart, float yEnd)
    {
        return Mathf.Abs(yStart - yEnd);
    }

    private void FindFlightDistances()
    {
        xDistance = FindXDistance(availabilityScript.previousMarkerPos.x, availabilityScript.thisMarkerPos.x);
        yDistance = FindYDistance(availabilityScript.previousMarkerPos.y, availabilityScript.thisMarkerPos.y);
        distanceMarkerToMarker = PythagoreanTheorem(xDistance, yDistance);
    }

    private void FindDistanceFromStart()
    {
        float xDistanceFromStart = FindXDistance(availabilityScript.previousMarkerPos.x, transform.position.x);
        float yDistanceFromStart = FindYDistance(availabilityScript.previousMarkerPos.y, transform.position.y);
        distanceStartToCurrent = PythagoreanTheorem(xDistanceFromStart, yDistanceFromStart);
    }

    private void FindDistanceToEnd()
    {
        float xDistanceToEnd = FindXDistance(transform.position.x, availabilityScript.thisMarkerPos.x);
        float yDistanceToEnd = FindYDistance(transform.position.y, availabilityScript.thisMarkerPos.y);
        distanceCurrentToEnd = PythagoreanTheorem(xDistanceToEnd, yDistanceToEnd);
    }

    private void Move()
    {
        if(availabilityScript.previousMarkerPos.x > availabilityScript.thisMarkerPos.x)
        {
            xMoveDirectionPosNeg = -1;
        }

        else
        {
            xMoveDirectionPosNeg = 1;
        }

        if(availabilityScript.previousMarkerPos.y > availabilityScript.thisMarkerPos.y)
        {
            yMoveDirectionPosNeg = -1;
        }

        else
        {
            yMoveDirectionPosNeg = 1;
        }

        if(xDistance > 0)
        {
            xMoveDistance = ((((xDistance * acceleration) / distanceMarkerToMarker) * speedModifier) * xMoveDirectionPosNeg) * Time.deltaTime;
        }
        
        else
        {
            xMoveDistance = 0;
        }

        if(yDistance > 0)
        {
            yMoveDistance = ((((yDistance * acceleration) / distanceMarkerToMarker) * speedModifier) * yMoveDirectionPosNeg) * Time.deltaTime;
        }

        else
        {
            yMoveDistance = 0;
        }

        straightMoveDistance = Mathf.Sqrt(Mathf.Pow(xMoveDistance, 2) + Mathf.Pow(yMoveDistance, 2));
        scaleFactor = 1.5f / (distanceToScaleUp / straightMoveDistance);

        float xMovementEachFrame = transform.position.x + xMoveDistance;
        float yMovementEachFrame = transform.position.y + yMoveDistance;

        if  (
            (xMoveDirectionPosNeg < 0 && transform.position.x > availabilityScript.thisMarkerPos.x) ||
            (xMoveDirectionPosNeg > 0 && transform.position.x < availabilityScript.thisMarkerPos.x) ||
            (yMoveDirectionPosNeg < 0 && transform.position.y > availabilityScript.thisMarkerPos.y) ||
            (yMoveDirectionPosNeg > 0 && transform.position.y < availabilityScript.thisMarkerPos.y)
            )

        {
            transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
        }

        else
        {
            Invoke("InvokeDestroy", 0.15f);
        }

        print("Scale: " + transform.localScale.x + ", " + transform.localScale.y);

        if (distanceStartToCurrent < distanceToScaleUp)
        {
            transform.localScale += new Vector3(scaleFactor, scaleFactor, 0f);
        }

        else if (distanceCurrentToEnd < distanceToScaleUp)
        {
            transform.localScale -= new Vector3(scaleFactor, scaleFactor, 0f);
        }

        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        }
    }

    private void InvokeDestroy()
    {
        Destroy(gameObject);
    }
}
