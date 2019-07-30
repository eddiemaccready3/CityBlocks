using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool pauseManual;
    public bool pauseAuto;

    private void Start()
    {
        pauseManual = false;
        pauseAuto = false;
    }

    void Update()
    {
        //print("PauseManual: " + pauseManual);
        //print("PauseAuto: " + pauseAuto);
    }
}
