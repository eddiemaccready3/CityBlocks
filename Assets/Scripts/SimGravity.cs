using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimGravity : MonoBehaviour
{
    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] AudioClip blockImpact;
    [SerializeField] GameObject blockOfNewColor;

    AudioSource audioSource;

    

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private bool isGrounded = false;
    
    private Vector2 currentPosition;
    private Vector2 newPositionBlockOfNewColor = new Vector2(-3, 4);
    private Vector2 collisionSpot = new Vector2(0, 9);

    Scene m_Scene;

    private string sceneName;

    void Start()
    {
        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        audioSource = GetComponent<AudioSource>();
        m_Scene = SceneManager.GetActiveScene();
        
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
        //checkForCollision = GameObject.Find ("CheckSpotForCollision");
        
        
        if (other.tag != "Spawner" && other.name != "ColorChanger")
        {
            GroundBlock();
        }

        //else if (other.name == "Stop1X3")
        //{
        //    if (hitColliders == null)
        //    {
        //        this.transform.position = new Vector2(xPosition, yPosition - 3);
        //    }

        //    else
        //    {
        //        GroundBlock();
        //    }
        //}

        else
        {
            isGrounded = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Collider2D hitColliders = Physics2D.OverlapCircle(collisionSpot, 0.05f);
        //checkForCollision = hitColliders.gameObject;
        //print("Collision object: " + checkForCollision);
        if (other.name == "ColorChanger")
        {
            Instantiate(blockOfNewColor, newPositionBlockOfNewColor, Quaternion.identity);
            //Destroy(this.gameObject);
        }
            
        isGrounded = false;
    }


    private void GroundBlock()
    {
        isGrounded = true;
        this.transform.position = new Vector2(xPosition, Mathf.Round(yPosition));
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(blockImpact);
        }
        //timeElapsed = 0f;
    }
}