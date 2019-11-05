using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLayerUnpause : MonoBehaviour
{
    [SerializeField] private int layersNotToIgnore;
    private PauseGameStatus pauseGameScript;

    private void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == layersNotToIgnore)
        {
            Destroy(other.gameObject);
            pauseGameScript.pauseAuto = false;
        }
    }
}
