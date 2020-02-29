using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetNewShapeMenuBool : MonoBehaviour
{
    private Scene scene;
    private string sceneName;
    
    private GameSaver gameSaverScript;

    private bool newShapeBoolSet = false;

    
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(newShapeBoolSet == false)
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyNewShapeAnnounced, 2);
            newShapeBoolSet = true;
        }
    }
}
