using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvasCamera : MonoBehaviour
{
    private Camera cam;

    private Canvas canv;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        canv = GetComponent<Canvas>();
        canv.worldCamera = cam;
    }
}
