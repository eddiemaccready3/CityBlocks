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

    private Collider2D hitColliders;

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private bool isGrounded = false;
    
    private Vector2 currentPosition;
    private Vector3 newPositionBlockOfNewColor = new Vector3(-3, 4, 0);
    private Vector2 collisionSpot = new Vector2(0, 4.25f);

    Scene m_Scene;

    private string sceneName;

    void Start()
    {
        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        audioSource = GetComponent<AudioSource>();
        m_Scene = SceneManager.GetActiveScene();
        isGrounded = false;
        
        
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

    private void EnableBoxCollider2D()
    {
        this.GetComponent<BoxCollider2D> ().enabled = true;
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.name == "ColorChanger")
    //    {
    //        isGrounded = false;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        print("On trigger enter with: " + other.name);
        //checkForCollision = GameObject.Find ("CheckSpotForCollision");
        Collider2D hitColliders = Physics2D.OverlapCircle(collisionSpot, 0.01f);
        //checkForCollision = hitColliders.gameObject;
        //print("Before if statements.");
        //print(hitColliders);

        if (other.tag != "Spawner" && other.name != "Stop1X3")
        {
            GroundBlock();
        }

        //else if (other.name == "ColorChanger")
        //{
        //    print("Color changed!");
        //    Instantiate(blockOfNewColor, transform.position, Quaternion.identity);
        //    isGrounded = false;
        //    Destroy(this.gameObject);
        //    //Destroy(this.gameObject);
        //}

        else
        {
            isGrounded = false;
        }

        if (other.name == "Stop1X3")
        {
            
            //print("Mesage hitcolliders" + hitColliders);
            if (hitColliders == null)
            {
                //print("Hit colliders = null");
                this.transform.position = new Vector2(xPosition, yPosition - 3);
            }

            else
            {
                //print("Else");
                GroundBlock();
            }
        }

        

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Collider2D hitColliders = Physics2D.OverlapCircle(collisionSpot, 0.05f);
        //checkForCollision = hitColliders.gameObject;
        //print("Collision object: " + checkForCollision);

        //if (other.name == "ColorChanger")
        //{
        //    print("Color changed!");
        //    Instantiate(blockOfNewColor, transform.position, Quaternion.identity);
        //    Destroy(this.gameObject);
        //}
        print("On trigger exit with: " + other.name);
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
        timeElapsed = 0f;
    }
}