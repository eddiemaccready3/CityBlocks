using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour {

    private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		currentPosition = new Vector2(this.transform.position.x - 0.4f, this.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(currentPosition, 0.01f);
        if(hitColliders != null)
        {
            Destroy(other.gameObject);
            Invoke("MoveLeft", 0.01f);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveLeft()
    {
        this.transform.position = new Vector2(this.transform.position.x - 10, this.transform.position.y);
    }
}
