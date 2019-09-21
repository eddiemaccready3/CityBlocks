using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    [SerializeField] public float delay;

	// Use this for initialization
	void Start ()
    {
        Invoke("DestroySelfGO", delay);
    }

    private void DestroySelfGO()
    {
        Destroy(gameObject);
    }
}
