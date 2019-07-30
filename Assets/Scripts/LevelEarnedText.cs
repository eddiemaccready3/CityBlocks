﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelEarnedText : MonoBehaviour
{
    [SerializeField] private Text pointsEarned;
    [SerializeField] private Text coinsEarned;
    [SerializeField] private Text matchesEarned;
    [SerializeField] private Text cityName;
    [SerializeField] private Text pointsReq;
    [SerializeField] private Text coinsReq;
    [SerializeField] private Text matchesReq;

    private Scene scene;
    private string sceneName;
    private string nextSceneName;
    private int thisSceneIndex;
    private int nextSceneIndex;

    private int pointsDisplayed = 0;
    private float coinsDisplayed = 0;
    private float matchesDisplayed = 0;

    public bool startAddingScore;
    public bool startAddingCoins;
    public bool startAddingMatches;

    private GameObject pointsStar;
    private GameObject coinsStar;

    private LevelPassReqs levelPassReqsScript;
    private SetStarStatus setStarStatusScript;
    private Counter counterScript;
    private UserInput userInputScript;
    private GameSaver gameSaverScript;
    private PauseGame pauseGameScript;

    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGame>();
        pauseGameScript.pauseAuto = false;
        pauseGameScript.pauseManual = false;

        levelPassReqsScript = FindObjectOfType<LevelPassReqs>();

        setStarStatusScript = FindObjectOfType<SetStarStatus>();
        counterScript = FindObjectOfType<Counter>();
        userInputScript = FindObjectOfType<UserInput>();
        gameSaverScript = FindObjectOfType<GameSaver>();
        
        startAddingScore = true;
        startAddingCoins = true;
        startAddingMatches = true;

        pointsStar = GameObject.Find("PointsStar");
        coinsStar = GameObject.Find("CoinsStar");

        scene = SceneManager.GetActiveScene();
        thisSceneIndex = scene.buildIndex;
        nextSceneIndex = thisSceneIndex + 1;
        
        sceneName = scene.name;

        PlayerPrefs.SetString("keyCurrentLevel", gameSaverScript.sceneNames[thisSceneIndex]);
        PlayerPrefs.SetString("keyNextLevel", gameSaverScript.sceneNames[nextSceneIndex]);

        cityName.text = sceneName.ToString();
        

        pointsReq.text = levelPassReqsScript.passPoints.ToString();
        coinsReq.text = levelPassReqsScript.passCoins.ToString();
        matchesReq.text = levelPassReqsScript.passMatches.ToString();

        counterScript.scoreCurrentAmount = counterScript.scoreTotalAmount;
        counterScript.scoreBalanceText.text = counterScript.scoreCurrentAmount.ToString();


        SaveLevelInfo();
    }

    private void FixedUpdate()
    {
        if(startAddingScore == true)
        {
            ScoreCounter();
        }

        if(pointsStar.GetComponent<SpriteRenderer>().sprite.name == "filled star")
        {
            if(startAddingCoins == true)
            {
                CoinsCounter();
            }
        }

        if(coinsStar.GetComponent<SpriteRenderer>().sprite.name == "filled star")
        {
            if(startAddingMatches == true)
            {
                MatchesCounter();
            }
        }
    }

    private void ScoreCounter()
    {
        if (int.Parse(pointsEarned.text) < GlobalControl.Instance.scoreBalanceSave)
        {
            pointsDisplayed += 35;
            pointsEarned.text = pointsDisplayed.ToString();
        }

        else
        {
            pointsDisplayed = GlobalControl.Instance.scoreBalanceSave;
            pointsEarned.text = pointsDisplayed.ToString();
            startAddingScore = false;
        }
    }
    
    private void CoinsCounter()
    {
        if (int.Parse(coinsEarned.text) < GlobalControl.Instance.coinsBalanceSave)
        {
            coinsDisplayed+= 0.3f;
            coinsEarned.text = Mathf.Round(coinsDisplayed).ToString();
        }

        else
        {
            coinsDisplayed = GlobalControl.Instance.coinsBalanceSave;
            coinsEarned.text = coinsDisplayed.ToString();
            startAddingCoins = false;
        }
    }

    private void MatchesCounter()
    {
        if (int.Parse(matchesEarned.text) < GlobalControl.Instance.matchesBalanceSave)
        {
            matchesDisplayed+= 0.3f;
            matchesEarned.text = Mathf.Round(matchesDisplayed).ToString();
        }

        else
        {
            matchesDisplayed = GlobalControl.Instance.matchesBalanceSave;
            matchesEarned.text = matchesDisplayed.ToString();
            startAddingMatches = false;
        }
    }

    public void SaveLevelInfo()
    {
        //GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
        //if(theTimer != null)
        //{
        //    Timer timerScript = theTimer.GetComponent<Timer>();
        //}
        //GlobalControl.Instance.timeLeftSave = timerScript.timeLeft;
        GlobalControl.Instance.scoreBalanceSave = counterScript.scoreTotalAmount;
        GlobalControl.Instance.coinsBalanceSave = counterScript.coinsTotalAmount;
        GlobalControl.Instance.matchesBalanceSave = userInputScript.shapesMatched.Count;
        //print("Matches made: " + GlobalControl.Instance.matchesBalanceSave);
        //print("Saved Matches made: " + PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel));
        //print("Saved Matches made London: " + PlayerPrefs.GetInt("London" + gameSaverScript.keyHighMatchesPerLevel));
        //print("Scene name: " + sceneName);
        HighScoreSave();
        HighCoinsSave();
        HighMatchesSave();
        if(setStarStatusScript != null)
        {
            StarCountSave();
        }

        PlayerPrefs.SetInt(gameSaverScript.keyTotalCoinBalance, PlayerPrefs.GetInt(gameSaverScript.keyTotalCoinBalance) + counterScript.coinsTotalAmount);
        

        PlayerPrefs.Save();

    }

    public void StarCountSave()
    {
        if (setStarStatusScript.totalStarsEarned > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyStarsEarnedPerLevel))
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyStarsEarnedPerLevel, setStarStatusScript.totalStarsEarned);
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
        if (GlobalControl.Instance.matchesBalanceSave > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel))
        {
            PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel, GlobalControl.Instance.matchesBalanceSave);
            //print("Saved Matches made: " + PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel));
        }

        if (GlobalControl.Instance.matchesBalanceSave > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestMatch))
        {
            PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestMatch, GlobalControl.Instance.matchesBalanceSave);
        }
    }
}
