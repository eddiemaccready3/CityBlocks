using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateMenu : MonoBehaviour
{
    private GlobalControl globalControlScript;
    
    // Start is called before the first frame update
    void Start()
    {
        globalControlScript = FindObjectOfType<GlobalControl>();
        globalControlScript.deactivateMenu = true;
    }
}
