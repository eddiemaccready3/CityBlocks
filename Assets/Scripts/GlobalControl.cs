using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public bool deactivateMenu = false;
    
    public static GlobalControl Instance;

    private ScoreBoard scoreboardScript;
    private GameSaver gameSaverScript;

    public float timeLeftSave = 90f;
    public int scoreBalanceSave;
    public int coinsBalanceSave;
    public int matchesBalanceSave;

    private void Start()
    {
        scoreboardScript = FindObjectOfType<ScoreBoard>();
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    void Awake ()   
        {
        if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy (gameObject);
            }
        }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            scoreboardScript.HighScoreSave();
            PlayerPrefs.Save();
            Application.Quit();
        }

        //if (Input.GetKey("backspace"))
        //{
        //    PlayerPrefs.DeleteAll();
        //}

        //if (Input.touchCount == 4)
        //{

        //    //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //    //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt("Venice" + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);
        //    //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);

        //    //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //    //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);
        //    //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);

        //    PlayerPrefs.SetInt(gameSaverScript.thanksForPlayingCompleted, 0);
        //}
    }
}
