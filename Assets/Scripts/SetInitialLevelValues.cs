using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetInitialLevelValues : MonoBehaviour
{
    [SerializeField] public GameObject newShapeMenu;

    [SerializeField] private float camStartX;
    [SerializeField] private float camStartY;
    [SerializeField] private float camStartZoom;
    
    Scene thisScene;
    private string sceneName;

    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        thisScene = SceneManager.GetActiveScene();
        sceneName = thisScene.name;

        gameSaverScript = FindObjectOfType<GameSaver>();
        Invoke("SetFirstRunValues", 15f);

        PlayerPrefs.SetFloat(gameSaverScript.cameraStartX, camStartX);
        PlayerPrefs.SetFloat(gameSaverScript.cameraStartY, camStartY);
        PlayerPrefs.SetFloat(gameSaverScript.cameraStartZoom, camStartZoom);
    }

    private void SetFirstRunValues()
    {
        PlayerPrefs.SetInt(sceneName + gameSaverScript.keyLevelIntroCompleted, 1);
    }
}
