using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGravity : MonoBehaviour
{
    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] AudioClip blockImpact;

    AudioSource audioSource;

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float moveDistance;

    private bool isGrounded = false;
    
    private Vector2 currentPosition;
    private float xPosition;
    private float yPosition;

    void Start()
    {
        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            MoveDown();
        }
    }


    private void MoveDown()
    {
        yPosition = transform.position.y;
        moveDistance = gravityAcceleration * Time.deltaTime * timeElapsed * gravityModifier;
        yMovementEachFrame = yPosition + moveDistance;
        transform.position = new Vector2(xPosition, yMovementEachFrame);
        timeElapsed += Time.deltaTime;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Spawner")
        {
            GroundBlock();
        }

        else
        {
            isGrounded = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }

    private void GroundBlock()
    {
        isGrounded = true;
        transform.position = new Vector2(xPosition, Mathf.Round(yPosition));
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(blockImpact);
        }
        //timeElapsed = 0f;
    }
}