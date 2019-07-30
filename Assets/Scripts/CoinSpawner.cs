using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin;

    private int i;

    void Start ()
    {
        i = Random.Range(1, 100);

        // Spawn coin at center of Block
        if(i > 75)
        {
            Instantiate(goldCoin, transform.position, Quaternion.identity, transform);
	    }
    }
}
