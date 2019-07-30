using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

	[SerializeField] private float speedModifier = 1f;
    [SerializeField] private float yMoveFactor = 0f;
    [SerializeField] private float accelerationMin = 1f;
    [SerializeField] private float accelerationMax = 3f;

    private float acceleration;
    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float moveDistance;
    private float xPosition;
    private float yPosition;
    private Vector2 currentPosition;

    // Use this for initialization
	void Start()
    {
        currentPosition = transform.position;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        acceleration = Random.Range (accelerationMin, accelerationMax);
    }
	
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        moveDistance = acceleration * Time.deltaTime * speedModifier;
        xMovementEachFrame = xPosition - moveDistance;
        yMovementEachFrame = yPosition - (moveDistance * yMoveFactor);
        transform.position = new Vector2(xMovementEachFrame, yMovementEachFrame);
    }
}
