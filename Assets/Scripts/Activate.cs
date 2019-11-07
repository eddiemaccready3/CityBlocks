using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private int activatePointsEarned;
    [SerializeField] private int activatePointsReq;
    private int activateCoinsEarned;
    [SerializeField] private int activateCoinsReq;
    private int activateMatchesEarned;
    [SerializeField] private int activateMatchesReq;

    //[SerializeField] private string activateCityName;
    
    //[SerializeField] private string activatorTag;
    [SerializeField] private string activeMarkerName;
    [SerializeField] public string activeCityName;

    [SerializeField] private Camera cam;
    [SerializeField] private int sceneToLoadSet;
    public int sceneToLoadGet;

    [SerializeField] private GameObject levelMenu;
    private GameObject[] menuObjects;

    public bool activeMarker = false;
    private bool menuInstatiated = false;

    private SpinObject spinObjectScript;
    private LevelTextPopulater levelTextPopulatorScript;
    private GameSaver gameSaverScript;

    private SetStarStatusMapScreen setStarStatusMapScreenScript;

    //private ActivatorCollisions activatorCollisionsScript;
    
    // Start is called before the first frame update
    void Start()
    {
        activeMarker = false;
        gameSaverScript = FindObjectOfType<GameSaver>();
        setStarStatusMapScreenScript = FindObjectOfType<SetStarStatusMapScreen>();

        spinObjectScript = GetComponent<SpinObject>();

        levelMenu.transform.GetComponent<Canvas>().worldCamera = cam;

        PlayerPrefs.SetInt(activeCityName + gameSaverScript.keyScoreReqPerLevel, activatePointsReq);
        PlayerPrefs.SetInt(activeCityName + gameSaverScript.keyCoinsReqPerLevel, activateCoinsReq);
        PlayerPrefs.SetInt(activeCityName + gameSaverScript.keyMatchesReqPerLevel, activateMatchesReq);
    }

    void Update()
    {
        if(activeMarker == true)
        {
            //activeCityName = activeMarkerName;

            //setStarStatusMapScreenScript.starCityName = activeCityName;
            spinObjectScript.rotateMarker = true;

            sceneToLoadGet = sceneToLoadSet;

            if (menuInstatiated == false)
            {
                Instantiate(levelMenu, Vector2.zero, Quaternion.identity);
                levelMenu.transform.GetComponent<Canvas>().worldCamera = cam;
                menuInstatiated = true;

                levelTextPopulatorScript = FindObjectOfType<LevelTextPopulater>();
                
                levelTextPopulatorScript.cityName.text = activeCityName;

                
                levelTextPopulatorScript.pointsEarned.text = PlayerPrefs.GetInt(activeCityName + gameSaverScript.keyHighScoresPerLevel).ToString();
                levelTextPopulatorScript.pointsReq.text = activatePointsReq.ToString();
                levelTextPopulatorScript.coinsEarned.text = PlayerPrefs.GetInt(activeCityName + gameSaverScript.keyHighCoinsPerLevel).ToString();
                levelTextPopulatorScript.coinsReq.text = activateCoinsReq.ToString();
                levelTextPopulatorScript.matchesEarned.text = PlayerPrefs.GetInt(activeCityName + gameSaverScript.keyHighMatchesPerLevel).ToString();
                levelTextPopulatorScript.matchesReq.text = activateMatchesReq.ToString();

                //print("Active City Name: " + activeCityName);
                
            }
        }

        else if(activeMarker == false)
        {
            if(PlayerPrefs.GetInt(gameSaverScript.keyStartingMarkerSpin) != 0)
            {
                spinObjectScript.rotateMarker = false;
                spinObjectScript.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            menuInstatiated = false;
        }
    }
}
