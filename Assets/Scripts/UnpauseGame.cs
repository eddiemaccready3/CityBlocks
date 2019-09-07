using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseGame : MonoBehaviour
{
    [SerializeField] private float unpauseDelay;
    private PauseGameStatus pauseGameScript;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        Invoke("Unpause", unpauseDelay);
    }

    private void Unpause()
    {
        pauseGameScript.pauseAuto = false;
        pauseGameScript.pauseManual = false;
    }
}
