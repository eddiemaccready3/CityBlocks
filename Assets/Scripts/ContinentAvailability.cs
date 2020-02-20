using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentAvailability : MonoBehaviour
{
    [SerializeField] private string previousCityName;
    [SerializeField] private string thisCityName;
    [SerializeField] private string nextCityName;
    
    [SerializeField] private Sprite available;
    [SerializeField] private Sprite availableNoStar;
    [SerializeField] private Sprite unavailable;

    private SpriteRenderer spriteRenderer; 

    private GameSaver gameSaverScript;

    public bool levelAvailable;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = unavailable;
        }

        gameSaverScript = FindObjectOfType<GameSaver>();
        
        if (PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(previousCityName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0)
        {
            levelAvailable = true;
        }
        else
        {
            levelAvailable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelAvailable == true)
        {
            if (PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0)// || PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0)
            {
                spriteRenderer.sprite = available;
            }

            else
            {
                spriteRenderer.sprite = availableNoStar;
            }
        }

        else
        {
            spriteRenderer.sprite = unavailable;
        }
    }
}