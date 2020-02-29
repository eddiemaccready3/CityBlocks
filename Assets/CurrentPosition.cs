using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;

       //print("Current location: " + this.transform.position);
       //print(xPos + ", " + yPos + ", " + zPos);
    }
}
