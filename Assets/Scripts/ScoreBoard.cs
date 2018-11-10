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
    private Timer timerScript;
    private GameObject theTimer;

    public int ScoreSave;

    [SerializeField] private int londonEndScore;
    [SerializeField] private int amsterdamEndScore;
    [SerializeField] private int newYorkEndScore;
    [SerializeField] private int parisEndScore;
    [SerializeField] private int newDelhiEndScore;
    [SerializeField] private int veniceEndScore;
    
     // Use this for initialization
        
    void Start()
    {
        GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
        Timer timerScript = theTimer.GetComponent<Timer>();
        score = GlobalControl.Instance.scoreSave;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
        if (score > londonEndScore && sceneName == "London")
        {
            SaveLevelInfo();
            Invoke("LoadScene4", 0.25f);
        }

        else if (score > amsterdamEndScore && sceneName == "Amsterdam")
        {
            SaveLevelInfo();
            Invoke("LoadScene5", 0.25f);
        }

        else if (score > newYorkEndScore && sceneName == "NewYork")
        {
            SaveLevelInfo();
            Invoke("LoadScene6", 0.25f);
        }

        else if (score > parisEndScore && sceneName == "Paris")
        {
            SaveLevelInfo();
            Invoke("LoadScene7", 0.25f);
        }

        else if (score > newDelhiEndScore && sceneName == "NewDelhi")
        {
            SaveLevelInfo();
            Invoke("LoadScene8", 0.25f);
        }

        else if (score > veniceEndScore && sceneName == "Venice")
        {
            SaveLevelInfo();
            Invoke("LoadScene2", 0.25f);
        }
    }

    private void LoadScene2()
    {
        SceneManager.LoadScene(2);
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

    public void SaveLevelInfo()
    {
        GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
        Timer timerScript = theTimer.GetComponent<Timer>();
        GlobalControl.Instance.scoreSave = score;
        GlobalControl.Instance.timeLeftSave = timerScript.timeLeft;
    }
}
