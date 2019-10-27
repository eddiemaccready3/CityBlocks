using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCameraZoom : MonoBehaviour
{
    [SerializeField] private float cameraStartZoom;
    [SerializeField] private float cameraEndZoom;
    [SerializeField] private float cameraZoomSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomStartDelay;

    private float orthoSize;

    public bool autoZoomComplete = false;

    private GameSaver gameSaverScript;
    private PauseGameStatus pauseGameStatusScript;

    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        pauseGameStatusScript = FindObjectOfType<PauseGameStatus>();
        
        orthoSize = cameraStartZoom;

        if (PlayerPrefs.GetInt(gameSaverScript.keyFirstMapZoom) == 0)
        {
            cam.orthographicSize = orthoSize;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad > zoomStartDelay)
        {
            if(PlayerPrefs.GetInt(gameSaverScript.keyFirstMapZoom) == 0 && autoZoomComplete == false)
            {
                if(cam.orthographicSize > cameraEndZoom)
                {
                    orthoSize -= (cameraZoomSpeed * Time.deltaTime);
                    cam.orthographicSize = orthoSize;
                    pauseGameStatusScript.pauseAuto = true;
                }
        
                else
                {
                    cam.orthographicSize = cameraEndZoom;
                    pauseGameStatusScript.pauseAuto = false;
                    autoZoomComplete = true;
                    PlayerPrefs.SetInt(gameSaverScript.keyFirstMapZoom, 1);
                }
            }
        }
    }
}
