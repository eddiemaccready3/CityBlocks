using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprayer : MonoBehaviour {

    private float depth = 8f;

	// Use this for initialization
	void Start () {

        Cursor.visible = true;
        GetComponent<TrailRenderer>().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButton(0))
        {
            GetComponent<TrailRenderer>().enabled = true;
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, depth));
            transform.position = wantedPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(this.gameObject);
            GetComponent<TrailRenderer>().enabled = false;
        }
    }

}
