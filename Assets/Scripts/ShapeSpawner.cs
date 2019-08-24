using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    public GameObject[] shapes;
    private int i;

    void Start () {

    int i = Random.Range(0, shapes.Length);
    
    Instantiate(shapes[i],
                transform.position,
                Quaternion.identity);

	}

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.gameObject.layer == 11)
        {
            int i = Random.Range(0, shapes.Length);

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
