using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    public int qty;
    public GameObject[] shapes;

    void Start () {

    int i = Random.Range(0, shapes.Length);
        

    // Spawn Block at current Position
    Instantiate(shapes[i],
                transform.position,
                Quaternion.identity);
	}

    public void OnTriggerExit2D(Collider2D other)
    {
        qty = 0;
        
        int i = Random.Range(0, shapes.Length);
        

        // Spawn Block at current Position
        Instantiate(shapes[i],
                    transform.position,
                    Quaternion.identity);
        qty++;
    }
}
