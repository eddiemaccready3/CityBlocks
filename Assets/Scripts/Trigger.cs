using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	GameObject referenceObject;
    SimGravity referenceScript;
    private float xPos;
    private float yPos;
    
    GameObject other;
    

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Trigger")
        {
            referenceObject = other.gameObject;
            referenceScript = referenceObject.GetComponent<SimGravity>();
            //referenceScript.isGrounded = false;
        }
    }
}
