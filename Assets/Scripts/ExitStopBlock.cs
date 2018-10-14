using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStopBlock : MonoBehaviour {

	[SerializeField] GameObject isGroundedSetToFalse;
    
    GameObject tempGameObject;
    
    private Vector2 tempMoveRight;
    private Vector2 tempMoveUp;
    
    // Use this for initialization
	void Start () {

    tempMoveRight = new Vector2 (transform.position.x - 10f, transform.position.y + 2.5f);
    tempMoveUp = new Vector2 (transform.position.x, transform.position.y + 2.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D other)
    {
        print("Stop Block On trigger exit with: " + other.name);
        Instantiate(isGroundedSetToFalse, tempMoveUp, Quaternion.identity);
        Invoke("MoveRight", 0.05f);
    }

    private void MoveRight()
    {
        tempGameObject = GameObject.FindGameObjectWithTag("IsGroundedSet");
        tempGameObject.transform.position = tempMoveRight;

        Invoke("DestroyTempGameObject", 0.05f);
    }

    private void DestroyTempGameObject()
    {
        Destroy(tempGameObject);
    }

}
