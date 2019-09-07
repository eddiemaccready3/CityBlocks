using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private float pauseDelay;
    private PauseGameStatus pauseGameScript;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        Invoke("Pause", pauseDelay);
    }

    private void Pause()
    {
        pauseGameScript.pauseAuto = true;
        pauseGameScript.pauseManual = true;
    }
}
