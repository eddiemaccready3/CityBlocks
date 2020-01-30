using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraStartPos : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        
        if(PlayerPrefs.GetInt(gameSaverScript.keyFirstMapZoom) == 1)
        {
            transform.position = new Vector3 (PlayerPrefs.GetFloat(gameSaverScript.cameraStartX), PlayerPrefs.GetFloat(gameSaverScript.cameraStartY), -10f);
            cam.orthographicSize = PlayerPrefs.GetFloat(gameSaverScript.cameraStartZoom);
        }
    }
}
