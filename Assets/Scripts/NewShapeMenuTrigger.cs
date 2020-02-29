using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewShapeMenuTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 menuPos;
    [SerializeField] private GameObject newShapeMenu;

    private Scene scene;
    private string sceneName;
    
    private GameSaver gameSaverScript;

    private bool newShapeMenuInstantiate = false;

    
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
        if ((newShapeMenu != null) && (PlayerPrefs.GetInt(sceneName + gameSaverScript.keyNewShapeAnnounced) == 1))
        {
            if(newShapeMenuInstantiate == false)
            {
                Instantiate(newShapeMenu, menuPos, Quaternion.identity);
                newShapeMenuInstantiate = true;
            }
        }
    }
}