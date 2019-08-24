using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorCollisions : MonoBehaviour
{
    public bool collidingWithMarker;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Marker")
        {
            collidingWithMarker = false;
        }

        else
        {
            collidingWithMarker = true;
        }
    }
}
