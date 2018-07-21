using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float timeLeft = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {        
        timeLeft -= Time.deltaTime;
                
        //Debug.Log(timeLeft);
        //Debug.Log(Mathf.Round(timeLeft));
	}
}
