using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfUnpause : MonoBehaviour
{
    [SerializeField] public float delay;

    private PauseGameStatus pauseGameScript;

	// Use this for initialization
	void Start ()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        Invoke("DestroySelfGO", delay);
    }

    private void DestroySelfGO()
    {
        pauseGameScript.pauseAuto = false;
        Destroy(gameObject);
    }
}
