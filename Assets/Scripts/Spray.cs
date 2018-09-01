using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour {

    public Transform spray;
    private float depth = 8f;

	// Use this for initialization
	void Start () {

        Cursor.visible = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePos = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, depth));
        transform.position = wantedPos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(spray, transform.position, transform.rotation);
        }
    }

    //private void FixedUpdate()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Instantiate(spray, transform.position, transform.rotation);
    //    }
    //}

}
