using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimGravity : MonoBehaviour
{
    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] GameObject blockOfNewColor;

    private Collider2D [] hitColliders;
    private int qtyCollidersHit;

    private float gravityAcceleration = -9.8f;
    private float yMovementEachFrame;
    private float timeElapsed;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private int blockFallCounter;
    private int qtyCollidersHitCounter;
    private Vector2 overlapBoxPosition;
    private Vector2 overlapBoxSize;

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
        yPosition = transform.position.y;
        m_Scene = SceneManager.GetActiveScene();
        isGrounded = false;

        

        //blockFallCounter = GameObject.Find("Stop1X3").GetComponent<ExitStopBlock>().blockFallCount5;
        //if(this.gameObject.transform.position.x == 0)
        //{
        //    qtyCollidersHitCounter = GameObject.Find("Stop1X3").GetComponent<ExitStopBlock>().qtyCollidersHit;
        //}
        
    }

    //private void Update()
    //{
    //    overlapBoxPosition = new Vector2 (transform.position.x, transform.position.y - 0.53f);
    //    overlapBoxSize = new Vector2 (0.27f, 0.13f);
    //    hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0);
    //    qtyCollidersHit = hitColliders.Length;
    //    if (hitColliders.Length > 0)
    //    {
    //        isGrounded = true;
    //    }

    //    else
    //    {
    //        isGrounded = false;
    //    }
    //}

    private void FixedUpdate()
    {
        CheckForCollisions();
        MoveOrGround();
    }

    private void MoveOrGround()
    {
        if (!isGrounded)
        {
            MoveDown();
        }
        
        else
        {
            GroundBlock();
        }
    }

    private void CheckForCollisions()
    {
        overlapBoxPosition = new Vector2(transform.position.x, transform.position.y - 0.85f);
        overlapBoxSize = new Vector2(0.25f, 0.85f);
        hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0);
        qtyCollidersHit = hitColliders.Length;
        //if (hitColliders.Length > 0)
        //{
        //    print("hitColldersLength before " + hitColliders[0]);
        //}
        if (hitColliders.Length < 1)
        {
            isGrounded = false;
        }

        else if (hitColliders.Length > 0)
        {
            if (hitColliders[0] == null)
            {
                isGrounded = false;
            }
        }

        Array.Clear(hitColliders, 0, hitColliders.Length);
        //if (hitColliders.Length > 0)
        //{
        //    print("hitColldersLength after " + hitColliders[0]);
        //}

        //else
        //{
        //    isGrounded = false;
        //}
    }

    private void MoveDown()
    {
        //hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0);
        //qtyCollidersHit = hitColliders.Length;
        //if (hitColliders.Length > 0)
        //{
            yPosition = transform.position.y;
            //print(this.gameObject.name + " yPos " + yPosition);
            moveDistance = gravityAcceleration * Time.deltaTime * timeElapsed * gravityModifier;
            
            CheckForCollisions();

            if (hitColliders.Length > 0 && (yPosition - Math.Floor(yPosition)) < Math.Abs(moveDistance))
            {
                isGrounded = true;
            }
            
            else
            {
                yMovementEachFrame = yPosition + moveDistance;
                transform.position = new Vector2(xPosition, yMovementEachFrame);
                timeElapsed += Time.deltaTime;
                isGrounded = false;
            }
        //}

        //else
        //{
        //    isGrounded = true;
        //}

    }

    //private void EnableBoxCollider2D()
    //{
    //    this.GetComponent<BoxCollider2D> ().enabled = true;
    //}

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.name == "ColorChanger")
    //    {
    //        isGrounded = false;
    //    }
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    //print("On trigger enter with: " + other.name);
    //    //checkForCollision = GameObject.Find ("CheckSpotForCollision");
    //    //Collider2D hitColliders = Physics2D.OverlapCircle(collisionSpot, 0.01f);
    //    //checkForCollision = hitColliders.gameObject;
    //    //print("Before if statements.");
    //    //print(hitColliders);
    //    //print("SimGravity BlockFallCounter: " + blockFallCounter);
    //    //rint("HitColliderCounter from SimGrav: " + qtyCollidersHitCounter);
    //    if(other.tag == "Ground" || other.gameObject.layer == 12 || other.tag == "Stopper")// && qtyCollidersHitCounter > 5))
    //    {    
    //        GroundBlock();
    //    }

    //    //if (other.tag != "Spawner")
    //    //{
    //    //    if(other.tag == "Stopper" && blockFallCounter < 1)
    //    //    {    
    //    //        GroundBlock();
    //    //    }
    //    //}

    //    //else if (other.name == "ColorChanger")
    //    //{
    //    //    print("Color changed!");
    //    //    Instantiate(blockOfNewColor, transform.position, Quaternion.identity);
    //    //    isGrounded = false;
    //    //    Destroy(this.gameObject);
    //    //    //Destroy(this.gameObject);
    //    //}

    //    else
    //    {
    //        isGrounded = false;
    //    }

    //    //if (other.name == "Stop1X3")
    //    //{
            
    //    //    //print("Mesage hitcolliders" + hitColliders);
    //    //    if (hitColliders == null)
    //    //    {
    //    //        //print("Hit colliders = null");
    //    //        this.transform.position = new Vector2(xPosition, yPosition - 3);
    //    //    }

    //    //    else
    //    //    {
    //    //        //print("Else");
    //    //        GroundBlock();
    //    //    }
    //    //}

        

    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    //Collider2D hitColliders = Physics2D.OverlapCircle(collisionSpot, 0.05f);
    //    //checkForCollision = hitColliders.gameObject;
    //    //print("Collision object: " + checkForCollision);

    //    //if (other.name == "ColorChanger")
    //    //{
    //    //    print("Color changed!");
    //    //    Instantiate(blockOfNewColor, transform.position, Quaternion.identity);
    //    //    Destroy(this.gameObject);
    //    //}
    //    //print("On trigger exit with: " + other.name);
    //    if(other.gameObject.layer != 13)
    //    {
    //        isGrounded = false;
    //    }
    //}


    private void GroundBlock()
    {
        //print(this.gameObject.name + " Groundblock yPos " + yPosition);
        //if ((yPosition - Math.Floor(yPosition)) > Math.Abs(moveDistance))
        //{
        //    print(this.gameObject.name + " greater than moveDistance Groundblock yPos " + yPosition);
        //    print("yPos - yPos Floor" + (yPosition - Math.Floor(yPosition)));
        //    print("moveDistance " + Math.Abs(moveDistance));
        //    //print ("Difference: " + (yPosition - Math.Floor(yPosition)));
        //    //print ("moveDistance: " + Math.Abs(moveDistance));
        //    isGrounded = false;
        //}
            
        //else
        //{
            isGrounded = true;
            //print("Actual position: " + this.transform.position.y + this.transform.gameObject.name);
            //print("Rounded position: " + Mathf.Floor(yPosition) + this.transform.gameObject.name);
            //print(this.gameObject.name + " less than moveDistance Groundblock yPos " + yPosition);
            this.transform.position = new Vector2(xPosition, Mathf.Floor(yPosition));
            //if (!audioSource.isPlaying)
            //{
            //    audioSource.PlayOneShot(blockImpact);
            //}
            timeElapsed = 0f;
        //}
    }
}