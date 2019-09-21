using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetInitialLevelValues : MonoBehaviour
{
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
    }

    private void SetFirstRunValues()
    {
        PlayerPrefs.SetInt(sceneName + gameSaverScript.keyLevelIntroCompleted, 1);
    }
}
