using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseGame : MonoBehaviour
{
    private PauseGame pauseGameScript;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGame>();
        Unpause();
    }

    private void Unpause()
    {
        pauseGameScript.pauseAuto = false;
        pauseGameScript.pauseManual = false;
    }
}
