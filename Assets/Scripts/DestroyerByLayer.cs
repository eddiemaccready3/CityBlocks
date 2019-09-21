using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerByLayer : MonoBehaviour
{
    [SerializeField] private int layersNotToIgnore;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == layersNotToIgnore)
        {
            Destroy(other.gameObject);
        }
    }
}
