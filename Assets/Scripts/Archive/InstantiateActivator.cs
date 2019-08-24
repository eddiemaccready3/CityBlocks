using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateActivator : MonoBehaviour
{
    [SerializeField] private GameObject activator;

    [SerializeField] private Transform activatorParent;

    private GameObject[] activatorObjects;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            activatorObjects = GameObject.FindGameObjectsWithTag("Activator");

            if(activatorObjects != null)
            {
                for (var i = 0; i < activatorObjects.Length; i++)
                {
                    Destroy(activatorObjects[i]);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(activator, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, activatorParent);
        }
    }
}
