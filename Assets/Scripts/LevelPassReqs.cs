using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelPassReqs : MonoBehaviour
{
    public int passPoints;
    public int passCoins;
    public int passMatches;

    private GameSaver gameSaverScript;

    private void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        
        passPoints = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + gameSaverScript.keyScoreReqPerLevel);
        passCoins = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + gameSaverScript.keyCoinsReqPerLevel);
        passMatches = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + gameSaverScript.keyMatchesReqPerLevel);
    }
}

