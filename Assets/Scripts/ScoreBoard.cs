using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour {

	[SerializeField] int scorePerHit = 12;
    int score;
    Text scoreText;
    private Scene scene;
    private string sceneName;
    
     // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }
    public void ScoreHit(int scorePerHit)
    {
        print("Scene Name: " + scene.name);
        score = score + scorePerHit;
        scoreText.text = score.ToString();
        if (score > 500 && sceneName == "London")
        {
            Invoke("LoadScene4", 0.25f);
        }

        else if (score > 1000 && sceneName == "Amsterdam")
        {
            Invoke("LoadScene5", 0.25f);
        }
    }

    private void LoadScene4()
    {
        SceneManager.LoadScene(4);
    }

    private void LoadScene5()
    {
        SceneManager.LoadScene(5);
    }

    private void LoadScene6()
    {
        SceneManager.LoadScene(6);
    }

    private void LoadScene7()
    {
        SceneManager.LoadScene(7);
    }

    private void LoadScene8()
    {
        SceneManager.LoadScene(8);
    }
}
