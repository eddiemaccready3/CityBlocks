﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public int qty;
    public GameObject[] blocks;

    private int i;

    void Start () {

    int i = Random.Range(0, blocks.Length);
    qty = 0;
        

    // Spawn Block at current Position
    Instantiate(blocks[i],
                transform.position,
                Quaternion.identity);

    
    
	}

    public void OnTriggerExit2D(Collider2D other)
    {

        
        int i = Random.Range(0, blocks.Length);
        

        // Spawn Block at current Position
        Instantiate(blocks[i],
                    transform.position,
                    Quaternion.identity);
        qty++;
    }

    

}
