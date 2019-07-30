using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour {

    //[SerializeField] int scorePerHit = 12;
    public int score;
    public int ScoreSave;

    private Text scoreText;
    
    private Scene scene;
    
    private string sceneName;
    
    private Timer timerScript;
    
    private GameObject theTimer;

    private Counter counterScript;
    private UserInput userInputScript;
    
    private GameSaver gameSaverScript;
    
    [SerializeField] private int nextSceneFromResults;

    //[SerializeField] private int londonEndScore;
    //[SerializeField] private int santoriniEndScore;
    //[SerializeField] private int zurichEndScore;
    //[SerializeField] private int parisEndScore;
    //[SerializeField] private int amsterdamEndScore;
    //[SerializeField] private int veniceEndScore;
    
     // Use this for initialization
        
    void Start()
    {
        GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
        Timer timerScript = theTimer.GetComponent<Timer>();

        counterScript = FindObjectOfType<Counter>();
        userInputScript = FindObjectOfType<UserInput>();
        gameSaverScript = FindObjectOfType<GameSaver>();

        score = GlobalControl.Instance.scoreBalanceSave;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    public void ScoreHit()
    {
        //score = score + scorePerHit;
        //scoreText.text = score.ToString();
        //scoreCounter = 0;

        if (sceneName == "London")//timerScript.timeLeft <= 0 && sceneName == "London")
        {
            SaveLevelInfo();
            Invoke("LoadScene4", 0.25f);
        }

        else if (sceneName == "Amsterdam")//timerScript.timeLeft <= 0 && sceneName == "Amsterdam")
        {
            SaveLevelInfo();
            Invoke("LoadScene5", 0.25f);
        }

        else if (sceneName == "Santorini")//timerScript.timeLeft <= 0 && sceneName == "Santorini")
        {
            SaveLevelInfo();
            Invoke("LoadScene6", 0.25f);
        }

        else if (sceneName == "Paris")//timerScript.timeLeft <= 0 && sceneName == "Paris")
        {
            SaveLevelInfo();
            Invoke("LoadScene7", 0.25f);
        }

        else if (sceneName == "Zurich")//timerScript.timeLeft <= 0 && sceneName == "Zurich")
        {
            SaveLevelInfo();
            Invoke("LoadScene8", 0.25f);
        }

        else if (sceneName == "Venice")//timerScript.timeLeft <= 0 && sceneName == "Venice")
        {
            SaveLevelInfo();
            Invoke("LoadScene2", 0.25f);

        }
    }

    private void LoadScene2()
    {
        GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
        Timer timerScript = theTimer.GetComponent<Timer>();
        GlobalControl.Instance.scoreBalanceSave = 0;
        GlobalControl.Instance.coinsBalanceSave = 0;
        GlobalControl.Instance.timeLeftSave = 124f;
        SceneManager.LoadScene(2);
    }
    private void LoadScene4()
    {
        SceneManager.LoadScene(nextSceneFromResults);
        SaveLevelInfo();
    }

    private void LoadScene5()
    {
        SceneManager.LoadScene(nextSceneFromResults);
        SaveLevelInfo();
    }

    private void LoadScene6()
    {
        SceneManager.LoadScene(nextSceneFromResults);
        SaveLevelInfo();
    }

    private void LoadScene7()
    {
        SceneManager.LoadScene(nextSceneFromResults);
        SaveLevelInfo();
    }

    private void LoadScene8()
    {
        SceneManager.LoadScene(nextSceneFromResults);
        SaveLevelInfo();
    }

    public void SaveLevelInfo()
    {
        GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
        Timer timerScript = theTimer.GetComponent<Timer>();
        //GlobalControl.Instance.timeLeftSave = timerScript.timeLeft;
        GlobalControl.Instance.scoreBalanceSave = counterScript.scoreTotalAmount;
        GlobalControl.Instance.coinsBalanceSave = counterScript.coinsTotalAmount;
        GlobalControl.Instance.matchesBalanceSave = userInputScript.shapesMatched.Count;
        HighScoreSave();
        HighCoinsSave();
        HighMatchesSave();

        PlayerPrefs.Save();

    }

    public void StarCountSave()
    {
        if (counterScript.scoreTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighScoresPerLevel))
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighScoresPerLevel, counterScript.scoreTotalAmount);
        }

        if (counterScript.scoreTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestScore))
        {
            PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestScore, counterScript.scoreTotalAmount);
        }
    }
    
    public void HighScoreSave()
    {
        if (counterScript.scoreTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighScoresPerLevel))
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighScoresPerLevel, counterScript.scoreTotalAmount);
        }

        if (counterScript.scoreTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestScore))
        {
            PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestScore, counterScript.scoreTotalAmount);
        }
    }

    public void HighCoinsSave()
    {
        if (counterScript.coinsTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighCoinsPerLevel))
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighCoinsPerLevel, counterScript.coinsTotalAmount);
        }

        if (counterScript.coinsTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestCoin))
        {
            PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestCoin, counterScript.coinsTotalAmount);
        }
    }

    public void HighMatchesSave()
    {
        if (counterScript.matchesTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel))
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel, counterScript.matchesTotalAmount);
        }

        if (counterScript.matchesTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestMatch))
        {
            PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestMatch, counterScript.matchesTotalAmount);
        }
    }
}
