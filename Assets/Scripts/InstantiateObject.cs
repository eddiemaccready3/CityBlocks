using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;

    [SerializeField] private float instantiateDelay;

    [SerializeField] private Vector2 instantiatePos;

    private float timeElapsed = 0;

    private bool instantiated = false;
    
    // Update is called once per frame
    void Update()
    {
        if(instantiated == false)
        {
            if(timeElapsed > instantiateDelay)
            {
                Instantiate(objectToInstantiate, instantiatePos, Quaternion.identity);
                instantiated = true;
            }
        }

        timeElapsed += Time.deltaTime;
    }
}
