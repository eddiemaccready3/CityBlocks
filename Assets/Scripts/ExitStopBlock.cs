using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStopBlock : MonoBehaviour {

	[SerializeField] GameObject isGroundedSetToFalse;
    [SerializeField] GameObject destroyExtraBlock;
    
    GameObject tempGameObject;
    
    private Vector2 tempMoveLeft;
    private Vector2 tempMoveUp3;
    private Vector2 tempMoveUp2;
    private Vector2 tempMoveUp1;
    
    // Use this for initialization
	void Start () {

    tempMoveLeft = new Vector2 (transform.position.x - 10f, transform.position.y + 3f);
    tempMoveUp3 = new Vector2 (transform.position.x, transform.position.y + 3f);
    tempMoveUp2 = new Vector2 (transform.position.x, transform.position.y + 2f);
    tempMoveUp1 = new Vector2 (transform.position.x, transform.position.y + 1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D other)
    {
        print("Stop Block On trigger exit with: " + other.name);
        tempGameObject = GameObject.FindGameObjectWithTag("IsGroundedSet");
        Instantiate(isGroundedSetToFalse, tempMoveUp3, Quaternion.identity);
        Instantiate(destroyExtraBlock, tempMoveUp2, Quaternion.identity);
        //Destroy(other.gameObject);
        //tempGameObject.transform.position = tempMoveUp3;
        Invoke("MoveObject", 0.05f);
    }

    private void MoveObject()
    {
        tempGameObject = GameObject.FindGameObjectWithTag("IsGroundedSet");
        tempGameObject.transform.position = tempMoveLeft;

        Invoke("DestroyTempGameObject", 0.05f);
    }



    //void OnTriggerExit2D(Collider2D other)
    //{
    //    Instantiate(isGroundedSetToFalse, tempMoveUp1, Quaternion.identity);
    //    tempGameObject = GameObject.FindGameObjectWithTag("IsGroundedSet");
    //    tempGameObject.transform.position = tempMoveUp1;
        
    //    MoveObject(other);
    //}

    //private void MoveObject(Collider2D other)
    //{
        
    //    Invoke("MoveRight", 0.05f);
    //    Invoke("DestroyTempGameObject", 0.1f);
    //}

    //private void MoveRight(Collider2D other)
    //{
    //    Destroy(other.gameObject);
    //    tempGameObject.transform.position = tempMoveRight;
    //}

    private void DestroyTempGameObject()
    {
        Destroy(tempGameObject);
    }

}
