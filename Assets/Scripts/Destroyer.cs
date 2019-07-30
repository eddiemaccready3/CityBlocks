using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private Transform child;
    private CoinsCounter coinsCounterScript;

    //private void Start()
    //{
    //    if(child.childCount > 0)
    //    {
    //        child = this.gameObject.transform.GetChild(0);
    //    }
    //    coinsCounterScript = FindObjectOfType<CoinsCounter>();
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Child coin tag: " + child.tag);
        //if(child.childCount > 0)
        //{
        //    if(child.tag == "Gold")
        //    {
        //        coinsCounterScript.startCoinCounter = true;
        //        coinsCounterScript.totalCoinBalance += 25;
        //    }
        //}
        Destroy(other.gameObject);
    }
}
