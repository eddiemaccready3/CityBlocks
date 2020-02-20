using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarkerAvailability : MonoBehaviour
{
    [SerializeField] private string previousCityName;
    [SerializeField] private string thisCityName;
    [SerializeField] private string nextCityName;
    [SerializeField] private string lastMarkerAvailable;
    [SerializeField] public string thisContinent;
    [SerializeField] public string previousContinent;
    [SerializeField] private string thisPadlockName;
    
    [SerializeField] private Sprite available;
    [SerializeField] private Sprite availableNoStar;
    [SerializeField] private Sprite unavailable;

    [SerializeField] private GameObject thanksForPlaying;
    [SerializeField] private GameObject plane;
    private GameObject dotsParentTran;

    [SerializeField] private Camera cam;

    [SerializeField] private GameObject worldCanvas;

    public Vector2 previousMarkerPos = new Vector2(40000, 40000);
    public Vector2 thisMarkerPos = new Vector2(40000, 40000);

    private SpriteRenderer spriteRenderer; 

    private GameSaver gameSaverScript;
    private PauseGameStatus pauseGameScript;

    public bool levelAvailable;

    private bool availabilityRunComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        dotsParentTran = GameObject.Find("PlaneTrail");

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = unavailable;
        }

        gameSaverScript = FindObjectOfType<GameSaver>();
        pauseGameScript = FindObjectOfType<PauseGameStatus>();

        //PlayerPrefs.SetInt("Zermatt" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Zermatt" + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Zermatt" + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Zermatt" + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);

        //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Venice" + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);

        //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyPointsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyCoinsStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyMatchesStarEarnedPerLevel, 0);
        //PlayerPrefs.SetInt("Bangkok" + gameSaverScript.keyPlaneFlightCompletedPerLevel, 0);

        //PlayerPrefs.SetInt(gameSaverScript.thanksForPlayingCompleted, 0);


        

        if (levelAvailable == true && gameObject.name == lastMarkerAvailable && PlayerPrefs.GetInt(gameSaverScript.thanksForPlayingCompleted) == 0)
        {
            pauseGameScript.pauseAuto = true;
            thanksForPlaying.transform.GetComponent<Canvas>().worldCamera = cam;
            Instantiate(thanksForPlaying, Camera.main.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt(gameSaverScript.thanksForPlayingCompleted, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(availabilityRunComplete == false)
        {
            if (PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0 || gameObject.name == "LondonMarker")
            {
                levelAvailable = true;
                if(gameObject.name != "LondonMarker")
                {
                    if(PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyPlaneFlightCompletedPerLevel) == 0)
                    {
                        GameObject previousMarker = GameObject.Find(previousCityName.Replace(" ", "") + "Marker");
                    
                        if(previousMarker != null)
                        {
                            previousMarkerPos = previousMarker.transform.position;
                            print("previousMarker: " + previousMarker.name);
                        }
                        GameObject thisMarker = GameObject.Find(thisCityName.Replace(" ", "") + "Marker");
                    
                        if(previousMarker != null)
                        {
                            thisMarkerPos = thisMarker.transform.position;
                            print("thisMarker: " + thisMarker.name);
                        }

                        PlayerPrefs.SetString("thisCityName", thisCityName.Replace(" ", ""));

                        float angleInRad = Mathf.Atan2(previousMarkerPos.x - thisMarkerPos.x, previousMarkerPos.y - thisMarkerPos.y);
                        float angleInDeg = angleInRad * (180 / Mathf.PI);

                        if (plane != null)
                        {
                            plane.transform.localScale = new Vector3(0.5F, 0.5f, 0f);
                        }
                    
                        if (plane != null)
                        {
                            print("Plane: " + plane.transform.gameObject.name);
                            print("Instantiate plane from: " + previousCityName + " to " + thisCityName);
                            Instantiate(plane, previousMarkerPos, Quaternion.Euler(0f, 0f, -angleInDeg + 180), dotsParentTran.transform);
                        }
                    
                        //print("Fly from " + previousCityName + " to " + thisCityName);
                        //print("Flight rad angle: " + angleInRad);
                        //print("Flight deg angle: " + angleInDeg);
                        PlayerPrefs.SetInt(previousCityName + gameSaverScript.keyPlaneFlightCompletedPerLevel, 1);
                        }

                    else
                    {
                        previousMarkerPos = new Vector2(40000, 40000);
                        thisMarkerPos = new Vector2(40000, 40000);
                    }
                }
            }

            else
            {
                levelAvailable = false;
            }

            availabilityRunComplete = true;
        }
        
        if (levelAvailable == true)
        {
            if(previousContinent != thisContinent)
            {
                if (PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0)
                {
                    spriteRenderer.sprite = available;
                }
                
                else if (PlayerPrefs.GetInt(thisPadlockName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0)
                {
                    spriteRenderer.sprite = availableNoStar;
                }
                
                else
                {
                    spriteRenderer.sprite = unavailable;
                }
            }
            
            else
            {
                if (PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0)
                {
                    spriteRenderer.sprite = available;
                }

                else
                {
                    spriteRenderer.sprite = availableNoStar;
                }
            }
        }

        else
        {
            spriteRenderer.sprite = unavailable;
        }

        //if(Input.GetKey("p"))
        //{
        //    GameObject previousMarker = GameObject.Find(previousCityName + "Marker");
        //    previousMarkerPos = previousMarker.transform.position;
        //    GameObject thisMarker = GameObject.Find(thisCityName + "Marker");
        //    thisMarkerPos = thisMarker.transform.position;

        //    PlayerPrefs.SetString("thisCityName", thisCityName);

        //    float angleInRad = Mathf.Atan2(previousMarkerPos.x - thisMarkerPos.x, previousMarkerPos.y - thisMarkerPos.y);
        //    float angleInDeg = angleInRad * (180 / Mathf.PI);

        //    plane.transform.localScale = new Vector3(0.5F, 0.5f, 0f);
        //    Instantiate(plane, previousMarkerPos, Quaternion.Euler(0f, 0f, -angleInDeg + 180));
        //}
    }
}
