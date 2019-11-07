using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartMarkerSpin : MonoBehaviour
{
    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        PlayerPrefs.SetInt(gameSaverScript.keyStartingMarkerSpin, 1);
    }
}
