using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

	[SerializeField] private float secondsToWait;

    
    private Scene scene;
    private int sceneIndex;
    private int nextSceneIndex;
    
    void Start ()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex + 1 > 9)
        {
            nextSceneIndex = 2;
        }
        
        else
        {
            nextSceneIndex = sceneIndex + 1;
        }

        Invoke("LoadLevel", secondsToWait);
	}

    private void LoadLevel()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
