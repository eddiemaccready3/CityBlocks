﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    public GameObject[] shapes;
    
    private int i;

    private bool firstShapesSpawned = false;

    private PauseGameStatus pauseGameScript;

    void Start ()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        firstShapesSpawned = false;
	}

    private void Update()
    {
        if(Time.time > 1f && pauseGameScript.pauseAuto == false && firstShapesSpawned == false)
        {
            i = Random.Range(0, shapes.Length);
            
            Instantiate(shapes[i],
                    transform.position,
                    Quaternion.identity);
            firstShapesSpawned = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.gameObject.layer == 11)
        {
            i = Random.Range(0, shapes.Length);

            StartCoroutine(InstantiateShape(i));
        }
    }

    IEnumerator InstantiateShape(int i)
    {
        yield return new WaitForSeconds(.1f);
        Instantiate(shapes[i],
            transform.position,
            Quaternion.identity);
    }
}
