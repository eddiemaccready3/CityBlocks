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

    public string musicVolumeSet = "keyBoolMusicVolumeSet";
    public string sfxVolumeSet = "keyBoolSfxVolumeSet";
    public string musicVolumeLevel = "musicVolumeLevel";
    public string sfxVolumeLevel = "sfxVolumeLevel";

    public string thanksForPlayingCompleted = "keyThanksForPlayingCompleted";

    public string keyPlaneFlightCompletedPerLevel = "keyPlaneFlightCompletedPerLevel";

    

    //User Tips:
    public int howToPlay;
    public int howToShuffle;
    public int howToEarnStars;
    public int howToGetHint;

    //Variables from other scripts


    private void Start()
    {
        musicAudioSource = Camera.main.GetComponentInChildren<AudioSource>();
        
        if (PlayerPrefs.GetInt(musicVolumeSet) == 0)
        {
            PlayerPrefs.SetFloat(musicVolumeLevel, 1f);
            PlayerPrefs.SetInt(musicVolumeSet, 1);
        }

        else
        {
            musicAudioSource.volume = PlayerPrefs.GetFloat(musicVolumeLevel);
        }

        if (PlayerPrefs.GetInt(sfxVolumeSet) == 0)
        {
            PlayerPrefs.SetFloat(sfxVolumeLevel, 1f);
            PlayerPrefs.SetInt(sfxVolumeSet, 1);
        }
        

        //musicVolume = 1f;
        //sfxVolume = 1f;

        
       
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + keyHighScoresPerLevel, data.bullets);
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + keyHighCoinsPerLevel, data.bullets);
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + keyHighMatchesPerLevel, data.bullets);

        ////if(
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + keyScoreStarPerLevel, data.bullets);
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + keyCoinsStarPerLevel, data.bullets);
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + keyMatchesStarPerLevel, data.bullets);
        
        
        
        //PlayerPrefs.SetString (userNames[0], data.characterName);
        //PlayerPrefs.SetFloat ("power_CharacterSlot" + characterSlot, data.power);
        //PlayerPrefs.SetInt ("bullets_CharacterSlot" + characterSlot, data.bullets);
        //PlayerPrefs.Save ();
    }
    

    //static void SaveGameData()
    //{
    //    PlayerPrefs.SetString (userNames[0], data.characterName);
    //    PlayerPrefs.SetFloat ("power_CharacterSlot" + characterSlot, data.power);
    //    PlayerPrefs.SetInt ("bullets_CharacterSlot" + characterSlot, data.bullets);
    //    PlayerPrefs.Save ();
    //}

    //static CharacterData LoadCharacter (int characterSlot)
    //{
    //    CharacterData loadedCharacter = new CharacterData ();
    //    loadedCharacter.characterName = PlayerPrefs.GetString ("characterName_CharacterSlot" + characterSlot);
    //    loadedCharacter.power = PlayerPrefs.GetFloat ("power_CharacterSlot" + characterSlot);
    //    loadedCharacter.bullets = PlayerPrefs.GetInt ("bullets_CharacterSlot" + characterSlot);

    //    return loadedCharacter;
    //}
}
