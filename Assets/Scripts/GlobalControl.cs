using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GlobalControl : MonoBehaviour {

    public bool deactivateMenu = false;
    
    public static GlobalControl Instance;

    private ScoreBoard scoreboardScript;
    private GameSaver gameSaverScript;

    public float timeLeftSave = 90f;
    public int scoreBalanceSave;
    public int coinsBalanceSave;
    public int matchesBalanceSave;

    [SerializeField] private string thisCityName = "Bangkok";
    [SerializeField] private string previousCityName = "Venice";

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
        //if (Input.GetKey("escape"))
        //{
        //    scoreboardScript.HighScoreSave();
        //    PlayerPrefs.Save();
        //    Application.Quit();
        //}

        //if (Input.GetKey("backspace"))
        //{
        //    PlayerPrefs.DeleteAll();
        //} 

        //if (Input.GetKey("r"))
        //{
        //    PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //    //PlayerPrefs.SetInt("AsiaPadlock" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //.SetInt("AsiaPadlock" + gameSaverScript.keyStarsEarnedPerLevel, 0);
        //PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt(previousCityName + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);
        //PlayerPrefs.SetInt(thisCityName + gameSaverScript.keySetBangkokMarkerToActive, 0);


        //}

        //if (Input.touchCount == 4)
        //{

        //    PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt("AsiaPadlock" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt("AsiaPadlock" + gameSaverScript.keyStarsEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //    PlayerPrefs.SetInt(previousCityName + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);
        //    PlayerPrefs.SetInt(thisCityName + gameSaverScript.keySetBangkokMarkerToActive, 0);
        //}
    }


    //Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
    //{
    //    var dependencyStatus = task.Result;
    //    if (dependencyStatus == Firebase.DependencyStatus.Available)
    //    {
    //      // Create and hold a reference to your FirebaseApp,
    //      // where app is a Firebase.FirebaseApp property of your application class.
    //      //   app = Firebase.FirebaseApp.DefaultInstance;

    //      // Set a flag here to indicate whether Firebase is ready to use by your app.
    //    } else
    //    {
    //      UnityEngine.Debug.LogError(System.String.Format(
    //        "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
    //      // Firebase Unity SDK is not safe to use here.
    //    }
    //});
}
