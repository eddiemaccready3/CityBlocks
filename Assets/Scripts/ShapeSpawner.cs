using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    //public int qty;
    public GameObject[] shapes;
    private int i;

    //private bool collision;

    void Start () {

    //qty = 0;
    //collision = false;

    int i = Random.Range(0, shapes.Length - 1);
    
    //print("Start " + i);
        

    // Spawn Shape at current Position
    Instantiate(shapes[i],
                transform.position,
                Quaternion.identity);

	}

    public void OnTriggerExit2D(Collider2D other)
    {
        int i = Random.Range(0, shapes.Length - 1);

        //collision = false;

        // Spawn Shape at current Position
        //if (collision == false)// & other.tag != "LeftTrigger")
        //{
        StartCoroutine(InstantiateShape(i));
        //InstantiateShape(i);
        //print("Current i " + i);
        //qty++;
        //}

        //else
        //{
        //collision = true;
        //}

    }

    IEnumerator InstantiateShape(int i)
    {
        yield return new WaitForSeconds(.1f);
        Instantiate(shapes[i],
            transform.position,
            Quaternion.identity);
    }
}
