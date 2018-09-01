using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGravity : MonoBehaviour
{
   [SerializeField] private float gravityModifier = 1f;

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float checkYMovementNextFrame;
    private float checkTimeElapsed;
    private float timeElapsed;
    private float moveDistance;
    RaycastHit2D rayHit;
    public Transform transformRayOrigin;
    public GameObject findRaycaster;
    
    private bool isGrounded = false;
    
    private Vector2 startPosition;
    private Vector2 currentPosition;
    private Vector2 startOfPositionCheckBelow;
    private Vector2 endOfPositionCheckBelow;
    private float xPosition;
    private float checkYPosition;
    private float yPosition;

    void Start()
    {
        timeElapsed = 0f;
        currentPosition = transform.position;
        xPosition = transform.position.x;
        transformRayOrigin = this.gameObject.transform.GetChild(0);
        findRaycaster = transform.Find ("RayCast").gameObject;
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            //CheckCollisionNextFrame();
            MoveDown();
        }
    }


    private void MoveDown()
    {
        yPosition = transform.position.y;
        moveDistance = gravityAcceleration * Time.deltaTime * timeElapsed * gravityModifier;
        yMovementEachFrame = yPosition + moveDistance;
        //Vector2 rayLength = new Vector2(this.transform.position.x, moveDistance);
        //Vector2 rayOrigin = findRaycaster.transform.position;
        //Vector2 rayDirection = Vector2.down;
        //RaycastHit2D rayHit = Physics2D.Raycast(rayOrigin, rayLength);

        //if (Physics2D.Raycast(rayOrigin, rayLength))
        //{
        //    GroundBlock();
        //}

        //else
        //{
            transform.position = new Vector2(xPosition, yMovementEachFrame);
            timeElapsed += Time.deltaTime;
        //}
    }

    //private void CheckCollisionNextFrame()
    //{
    //    Vector2 rayOrigin = this.transform.position;
    //    Vector2 rayDirection = Vector2.down;
    //    checkYPosition = transform.position.y;
    //    checkYMovementNextFrame = yPosition + (gravityAcceleration * Time.deltaTime * checkTimeElapsed * gravityModifier);
    //    Debug.DrawRay(rayOrigin, rayDirection, Color.green);
    //if(Physics.Raycast(rayOrigin, rayDirection, out rayHit, checkYMovementNextFrame))
    //{
    //    GroundBlock();
    //}
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        //startOfPositionCheckBelow = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
        //endOfPositionCheckBelow = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y - 1);
        

        if (other.tag != "Spawner")
        {
            GroundBlock();
        }

        //else if (other.tag == "Trigger")
        //{
        //    isGrounded = false;
        //}

        //else if(Physics2D.Linecast(startOfPositionCheckBelow, endOfPositionCheckBelow))
        //{
        //    print ("Start " + startOfPositionCheckBelow);
        //    print ("End " + endOfPositionCheckBelow);
        //    isGrounded = false;
        //}

        //else if (other.tag == "Destroyer")
        //{
        //    Destroy(gameObject);
        //    print("Destroy " + gameObject);
        //    Destroy(other.gameObject);
        //    print("Destroy other game object " + other.gameObject);
        //    isGrounded = false;
        //}

        else
        {
            isGrounded = false;
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Destroyer")
    //    { 
    //        print ("Destroyer contact!");
           
    //        //transform.position = new Vector2(xPosition, (yPosition - 0.25f));
    //    }
    //}

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }

    private void GroundBlock()
    {
        isGrounded = true;
        transform.position = new Vector2(xPosition, Mathf.Round(yPosition));
    }
}