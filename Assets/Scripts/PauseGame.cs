using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private float pauseDelay;
    private PauseGameStatus pauseGameStatusScript;
    
    // Start is called before the first frame update
    void Awake()
    {
        pauseGameStatusScript = FindObjectOfType<PauseGameStatus>();
        Invoke("Pause", pauseDelay);
    }

    private void Pause()
    {
        pauseGameStatusScript.pauseAuto = true;
        pauseGameStatusScript.pauseManual = true;
    }
}
