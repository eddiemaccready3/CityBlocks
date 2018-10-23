using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStopBlock : MonoBehaviour {

	[SerializeField] GameObject isGroundedSetToFalse;
    [SerializeField] GameObject destroyExtraBlock;
    [SerializeField] GameObject blockTrigger;

    [SerializeField] private Vector2 overlapBoxPosition;
    [SerializeField] private Vector2 overlapBoxSize;

    private Collider2D [] hitColliders;
    public int qtyCollidersHit;
    
    
    GameObject tempGameObject;

    public int blockFallCount5;
    
    private Vector2 tempMoveLeft;
    private Vector2 tempMoveUp3;
    private Vector2 tempMoveUp2;
    private Vector2 tempMoveUp1;
    private Vector2 tempMoveUp;
    
    
    // Use this for initialization
	void Start () {
    
    this.gameObject.GetComponent<Collider2D>().enabled = false;

    tempMoveLeft = new Vector2 (transform.position.x - 10f, transform.position.y + 3f);
    tempMoveUp3 = new Vector2 (transform.position.x, transform.position.y + 2.5f);
    tempMoveUp2 = new Vector2 (transform.position.x, transform.position.y + 2f);
    tempMoveUp1 = new Vector2 (transform.position.x, transform.position.y + 1f);
    tempMoveUp = new Vector2 (transform.position.x, (transform.lossyScale.y / 2) + transform.position.y + 0.5f);

    blockFallCount5 = 4;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0);
        qtyCollidersHit = hitColliders.Length;
        //print("hitColliders Length: " + hitColliders.Length);
        if (hitColliders.Length >= 5)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            //print("Hitcolliders = 5");
        }

        else
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
	}

void OnTriggerEnter2D(Collider2D other)
    {
        //print("ExitStopBlock blockFallCount before trigger: " + blockFallCount5);
        blockFallCount5--;
        
        //print("ExitStopBlock blockFallCount after trigger: " + blockFallCount5);
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    //if(qtyCollidersHit < 5)
    //    //{
    //        tempGameObject = GameObject.FindGameObjectWithTag("IsGroundedSet");
    //        Instantiate(blockTrigger, tempMoveUp, Quaternion.identity);
    //        Invoke("MoveObject", 0.05f);
    //    //}

    //    //hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0);
    //    //print("hitColliders Length: " + hitColliders.Length);
    //    //if (hitColliders.Length == 5)
    //    //{
    //    //    print("Hitcolliders = 5");
    //    //}
    //    //print("Stop Block On trigger exit with: " + other.name);
        
        
    //    //Instantiate(destroyExtraBlock, tempMoveUp2, Quaternion.identity);
    //    //Destroy(other.gameObject);
    //    //tempGameObject.transform.position = tempMoveUp3;
    //    //Invoke("MoveObject", 0.05f);
    //}

    

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
