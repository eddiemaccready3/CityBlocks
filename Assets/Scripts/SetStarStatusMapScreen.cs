using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStarStatusMapScreen : MonoBehaviour
{
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;
    
    [SerializeField] private string starType;

    public string starCityName;

    private bool changeSprite;
    private bool starFilled;
    private bool starSet = false;

    private Activate activateScript;
    private GameSaver gameSaverScript;
    private LevelTextPopulater levelTextPopulater;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelTextPopulater = FindObjectOfType<LevelTextPopulater>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = inactiveSprite;
        }

        changeSprite = false;

        activateScript = FindObjectOfType<Activate>();
        gameSaverScript = FindObjectOfType<GameSaver>();

        //print("Point Stars earned: " + PlayerPrefs.GetInt(activateScript.activeCityName + gameSaverScript.keyPointsStarEarnedPerLevel));
        //print("Coin Stars earned: " + PlayerPrefs.GetInt(activateScript.activeCityName + gameSaverScript.keyCoinsStarEarnedPerLevel));
        //print("Match Stars earned: " + PlayerPrefs.GetInt(activateScript.activeCityName + gameSaverScript.keyMatchesStarEarnedPerLevel));

        starCityName = levelTextPopulater.cityName.text;

        FillStars();

        //else
        //{
        //    starFilled = false;
        //}
    }

    void Update()
    {
        if(starSet == false)
        {
            if (starFilled == true)
            {
                spriteRenderer.sprite = activeSprite;
                starSet = true;
            }

            else
            {
                spriteRenderer.sprite = inactiveSprite;
                starSet = true;
            }
        }
    }

    private void FillStars()
    {
        if (starType == "Points" && PlayerPrefs.GetInt(starCityName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0)
        {
            starFilled = true;
            //print("Point Stars earned " + starCityName + ": " + PlayerPrefs.GetInt(starCityName + gameSaverScript.keyPointsStarEarnedPerLevel));
        }

        if (starType == "Coins" && PlayerPrefs.GetInt(starCityName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0)
        {
            starFilled = true;
            //print("Coin Stars earned " + starCityName + ": " + PlayerPrefs.GetInt(starCityName + gameSaverScript.keyCoinsStarEarnedPerLevel));
        }

        if (starType == "Matches" && PlayerPrefs.GetInt(starCityName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0)
        {
            starFilled = true;
            //print("Match Stars earned " + starCityName + ": " + PlayerPrefs.GetInt(starCityName + gameSaverScript.keyMatchesStarEarnedPerLevel));
        }
    }
}
