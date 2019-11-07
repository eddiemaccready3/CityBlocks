using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMarkerSpin : MonoBehaviour
{
    private GameSaver gameSaverScript;
    private SpinObject spinObjectScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        spinObjectScript = GetComponent<SpinObject>();
        
        if(PlayerPrefs.GetInt(gameSaverScript.keyStartingMarkerSpin) == 0)
        {
            spinObjectScript.rotateMarker = true;
        }
    }

    private void Update()
    {
        
    }
}
