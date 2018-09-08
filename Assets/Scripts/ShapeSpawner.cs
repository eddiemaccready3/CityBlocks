using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    public GameObject[] shapes;
    private int i;

    void Start () {

    int i = Random.Range(0, shapes.Length - 1);
    
    Instantiate(shapes[i],
                transform.position,
                Quaternion.identity);

	}

    public void OnTriggerExit2D(Collider2D other)
    {
        int i = Random.Range(0, shapes.Length - 1);

        StartCoroutine(InstantiateShape(i));
    }

    IEnumerator InstantiateShape(int i)
    {
        yield return new WaitForSeconds(.1f);
        Instantiate(shapes[i],
            transform.position,
            Quaternion.identity);
    }
}
