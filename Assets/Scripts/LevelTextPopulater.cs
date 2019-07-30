using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextPopulater : MonoBehaviour
{
    private CityInfo cityInfoScript;
    private Activate activateScript;

    [SerializeField] public Text pointsEarned;
    [SerializeField] public Text coinsEarned;
    [SerializeField] public Text matchesEarned;
    [SerializeField] public Text cityName;
    [SerializeField] public Text pointsReq;
    [SerializeField] public Text coinsReq;
    [SerializeField] public Text matchesReq;

    private int pointsReqValue;
    private int coinsReqValue;
    private int matchesReqValue;

    private void Awake()
    {
        activateScript = FindObjectOfType<Activate>();
        //cityName.text = activateScript.activeCityName.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //cityInfoScript = FindObjectOfType<CityInfo>();
        
        //pointsEarned.text = cityInfoScript.thisCityPointsEarned.ToString();
        //coinsEarned.text = cityInfoScript.thisCityCoinsEarned.ToString();
        //matchesEarned.text = cityInfoScript.thisCityMatchesEarned.ToString();

        //pointsReq.text = cityInfoScript.thisCityPassPoints.ToString();
        //coinsReq.text = cityInfoScript.thisCityPassCoins.ToString();
        //matchesReq.text = cityInfoScript.thisCityPassMatches.ToString();
    }
}
