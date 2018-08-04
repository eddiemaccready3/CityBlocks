using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    [SerializeField] GameObject other;

    void OnTriggerEnter2D(Collision hit)
    {
        if (hit.transform.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
            Destroy(other);
        }
    }
}
