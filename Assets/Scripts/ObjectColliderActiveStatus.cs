using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColliderActiveStatus : MonoBehaviour
{
    [SerializeField] private GameObject [] objectsToDeactivate;
    [SerializeField] private GameObject [] objectsToActivate;
    
    public void ActivateColliders()
    {
        foreach (GameObject g in objectsToActivate)
        {
            g.GetComponent<Collider2D>().enabled = true;
        }
    }

    public void DeactivateColliders()
    {
        foreach (GameObject g in objectsToDeactivate)
        {
            g.GetComponent<Collider2D>().enabled = false;
        }
    }
}
