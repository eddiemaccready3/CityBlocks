using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransparency : MonoBehaviour
{
    [SerializeField] private float transparencyValue;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparencyValue);
    }
}
