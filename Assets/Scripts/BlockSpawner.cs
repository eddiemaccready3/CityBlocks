using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public int qty;
    public GameObject[] blocks;
    private Collider2D[] hitColliders;
    private Vector2 overlapBoxPosition;
    private Vector2 instantiatePosition;
    private Vector2 overlapBoxSize;
    private int qtyCollidersHit;

    private int i;

    void Start () {

    int i = Random.Range(0, blocks.Length);
    qty = 0;
    overlapBoxPosition = new Vector2 (transform.position.x, transform.position.y - 1f);
    instantiatePosition = new Vector2 (transform.position.x, transform.position.y - 1f);
    overlapBoxSize = new Vector2 (.8f, 1.8f);
        

    // Spawn Block at current Position
    Instantiate(blocks[i],
                instantiatePosition,
                Quaternion.identity);

    
    
	}

    private void Update()
    {
        hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0, layerMask);
        qtyCollidersHit = hitColliders.Length;
        //print("hitColliders Length: " + hitColliders.Length);
        if (hitColliders.Length < 1)
        {
            int i = Random.Range(0, blocks.Length);
            Instantiate(blocks[i],
                    instantiatePosition,
                    Quaternion.identity);
            //print("Hitcolliders = 5");
        }
    }

    //public void OnTriggerExit2D(Collider2D other)
    //{

        
    //    int i = Random.Range(0, blocks.Length);
        

    //    // Spawn Block at current Position
    //    Instantiate(blocks[i],
    //                transform.position,
    //                Quaternion.identity);
    //    qty++;
    //}

    

}
