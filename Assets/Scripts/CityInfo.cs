using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityInfo : MonoBehaviour
{
    [SerializeField] public string thisCityName;

    [SerializeField] public int thisCityPassPoints;
    [SerializeField] public int thisCityPassCoins;
    [SerializeField] public int thisCityPassMatches;

    public int thisCityPointsEarned;
    public int thisCityCoinsEarned;
    public int thisCityMatchesEarned;

    private GameSaver gameSaverScript;

    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();

        PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyScoreReqPerLevel, thisCityPassPoints);
        PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyCoinsReqPerLevel, thisCityPassCoins);
        PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyMatchesReqPerLevel, thisCityPassMatches);

        thisCityPointsEarned = PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyHighScoresPerLevel);
        thisCityCoinsEarned = PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyHighCoinsPerLevel);
        thisCityMatchesEarned = PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyHighMatchesPerLevel);
    }
}
