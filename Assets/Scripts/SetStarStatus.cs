using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetStarStatus : MonoBehaviour
{
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;
    
    [SerializeField] private int minRequired;

    [SerializeField] private Text minReqText;

    private int textConvertedToInt;
    public int totalStarsEarned = 0;

    private bool changeSprite;

    private SpriteRenderer spriteRenderer;

    private string sceneName;

    private LevelPassReqs levelPassReqsScript;
    private GameSaver gameSaverScript;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = inactiveSprite;
        }

        changeSprite = false;

        textConvertedToInt = int.Parse(minReqText.text);

        levelPassReqsScript = FindObjectOfType<LevelPassReqs>();
        gameSaverScript = FindObjectOfType<GameSaver>();

        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        textConvertedToInt = int.Parse(minReqText.text);
        if(changeSprite == false)
        {
            if(gameObject.name == "PointsStar")
            {
                if(textConvertedToInt >= levelPassReqsScript.passPoints)
                {
                    spriteRenderer.sprite = activeSprite;
                    changeSprite = true;
                    PlayerPrefs.SetInt(sceneName + gameSaverScript.keyPointsStarEarnedPerLevel, 1);
                    totalStarsEarned++;
                    transform.localScale += new Vector3(0.1F, 0.1f, 0);
                    Invoke("ReduceSize", 0.25f);
                }
                else
                {
                     spriteRenderer.sprite = inactiveSprite;
                }
            }

            else if(gameObject.name == "CoinsStar")
            {
                if(textConvertedToInt >= levelPassReqsScript.passCoins)
                {
                    spriteRenderer.sprite = activeSprite;
                    changeSprite = true;
                    PlayerPrefs.SetInt(sceneName + gameSaverScript.keyCoinsStarEarnedPerLevel, 1);
                    totalStarsEarned++;
                    transform.localScale += new Vector3(0.1F, 0.1f, 0);
                    Invoke("ReduceSize", 0.25f);
                }
                else
                {
                     spriteRenderer.sprite = inactiveSprite;
                }
            }

            else if(gameObject.name == "MatchesStar")
            {
                if(textConvertedToInt >= levelPassReqsScript.passMatches)
                {
                    spriteRenderer.sprite = activeSprite;
                    changeSprite = true;
                    PlayerPrefs.SetInt(sceneName + gameSaverScript.keyMatchesStarEarnedPerLevel, 1);
                    totalStarsEarned++;
                    transform.localScale += new Vector3(0.1F, 0.1f, 0);
                    Invoke("ReduceSize", 0.25f);
                }
                else
                {
                     spriteRenderer.sprite = inactiveSprite;
                }
            }
        }

        //print("Total Stars earned: " + totalStarsEarned);
    }

    private void ReduceSize()
    {
        transform.localScale -= new Vector3(0.1F, 0.1f, 0);
    }
}
