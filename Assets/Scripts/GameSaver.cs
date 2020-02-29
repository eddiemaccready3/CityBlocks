using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    //[SerializeField] public int min
    
    //Game save data
    //Overall stats
    public string keyAllTimeHighestScore = "keyAllTimeHighestScore";
    public string keyAllTimeHighestCoin = "keyAllTimeHighestCoin";
    public string keyAllTimeHighestMatch = "keyAllTimeHighestMatch";
    public int coinsBalanceSave;

    public string keyTotalCoinBalance = "keyTotalCoinBalance";

    //Settings
    public float musicVolume;
    public float sfxVolume;

    private AudioSource musicAudioSource;

    //Level Data
    [SerializeField] public string [] sceneNames;
    
    //User Data
    public string [] userNames;
    public int [] currentUserNameIndex;

    //Stats for each Level
    public string keyHighScoresPerLevel = "keyHighScoresPerLevel";
    public string keyHighCoinsPerLevel = "keyHighCoinsPerLevel";
    public string keyHighMatchesPerLevel = "keyHighMatchesPerLevel";

    public string keyScoreReqPerLevel = "keyScoreReqPerLevel";
    public string keyCoinsReqPerLevel = "keyCoinsReqPerLevel";
    public string keyMatchesReqPerLevel = "keyMatchesReqPerLevel";

    public int starsEarnedPerLevel;
    public string keyStarsEarnedPerLevel = "keyStarsEarnedPerLevel";

    public string keyPointsStarEarnedPerLevel = "keyPointsStarEarnedPerLevel";
    public string keyCoinsStarEarnedPerLevel = "keyCoinsStarEarnedPerLevel";
    public string keyMatchesStarEarnedPerLevel = "keyMatchesStarEarnedPerLevel";

    public string keyNewShapeAnnounced = "keyNewShapeAnnounced";

    public string musicVolumeSet = "keyBoolMusicVolumeSet";
    public string sfxVolumeSet = "keyBoolSfxVolumeSet";
    public string musicVolumeLevel = "musicVolumeLevel";
    public string sfxVolumeLevel = "sfxVolumeLevel";

    //Keys for actions that happen once per game.
    public string thanksForPlayingCompleted = "keyThanksForPlayingCompleted";

    public string keyPlaneFlightCompletedPerLevel = "keyPlaneFlightCompletedPerLevel";

    public string keyLevelIntroCompleted = "keyLevelIntroCompleted";

    public string keyClearAllData = "keyClearAllData";

    public string keyStartingMarkerSpin = "keyStartingMarkerSpin";

    public string keySetBangkokMarkerToActive = "ketSetBangkokMarkerToActive";

    //Camera Settings
    public string keyFirstMapZoom = "keyFirstMapZoom";
    public string keyEndEuropeMapZoom = "keyEndEuropeMapZoom";
    public string cameraStartX = "cameraStartX";
    public string cameraStartY = "cameraStartY";
    public string cameraStartZoom = "cameraStartZoom";

    //Release management
    public string currentRelease = "currentRelease";

    

    //User Tips:
    public int howToPlay;
    public int howToShuffle;
    public int howToEarnStars;
    public int howToGetHint;

    //Variables from other scripts


    private void Start()
    {
        //PlayerPrefs.SetInt(keyClearAllData, 0);

        if (PlayerPrefs.GetInt(keyClearAllData) == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt(keyClearAllData, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyClearAllData, 1);
        }

        musicAudioSource = Camera.main.GetComponentInChildren<AudioSource>();
        
        if (PlayerPrefs.GetInt(musicVolumeSet) == 0)
        {
            PlayerPrefs.SetFloat(musicVolumeLevel, 1f);
            PlayerPrefs.SetInt(musicVolumeSet, 1);
        }

        //else
        //{
        //    musicAudioSource.volume = PlayerPrefs.GetFloat(musicVolumeLevel);
        //}

        if (PlayerPrefs.GetInt(sfxVolumeSet) == 0)
        {
            PlayerPrefs.SetFloat(sfxVolumeLevel, 1f);
            PlayerPrefs.SetInt(sfxVolumeSet, 1);
        }

        if(PlayerPrefs.GetInt(keyClearAllData) == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt(keyClearAllData, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyClearAllData, 1);
        }

        //Release updates
        if(PlayerPrefs.GetInt(currentRelease) < 110)
        {
            //Reset end of all available levels announcement
            PlayerPrefs.SetInt(thanksForPlayingCompleted, 0);

            //Reset camera position to Europe
            PlayerPrefs.SetFloat(cameraStartX, 84);
            PlayerPrefs.SetFloat(cameraStartY, 75);
            PlayerPrefs.SetFloat(cameraStartZoom, 730);

            //Reset plane flight from Venice
            PlayerPrefs.SetInt("Venice" + keyPlaneFlightCompletedPerLevel, 0);
            
            //Set to current release level
            PlayerPrefs.SetInt(currentRelease, 110);
        }
    }
}
