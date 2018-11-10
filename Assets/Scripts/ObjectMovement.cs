using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

	[SerializeField] private float speedModifier = 1f;

    private float acceleration;
    private float xMovementEachFrame;
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
        acceleration = Random.Range (1f, 3f);
    }
	
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        xPosition = transform.position.x;
        moveDistance = acceleration * Time.deltaTime * speedModifier;
        xMovementEachFrame = xPosition - moveDistance;
        transform.position = new Vector2(xMovementEachFrame, yPosition);
    }
}
