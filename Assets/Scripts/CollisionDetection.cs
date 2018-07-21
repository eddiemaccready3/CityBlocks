using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public bool isGrounded = false;
    private float currentYPosition;
    private float currentXPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D (Collider2D other)
        {
            if (other.transform.tag != "Spawner")
            {
                isGrounded = true;
            }

            currentYPosition = transform.position.y;
            currentXPosition = transform.position.x;
            if (isGrounded)
            {
                transform.position = new Vector2(currentXPosition, Mathf.Round(currentYPosition));
            }
        }
}
