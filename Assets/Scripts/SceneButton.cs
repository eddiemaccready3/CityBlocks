using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private int sceneToLoad;

    [SerializeField] private Vector3 hitShapePos;

    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;

    private string sceneName;

    public bool sceneButtonActive = false;
    public bool changeSprite = false;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private GlobalControl globalControlScript;
    private PauseGame pauseGame;
    //private Counter counterScript;
    //private UserInput userInputScript;
    //private GameSaver gameSaverScript;
    //private SetStarStatus setStarStatusScript;

 
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn;
        }

        globalControlScript = FindObjectOfType<GlobalControl>();
        //counterScript = FindObjectOfType<Counter>();
        //userInputScript = FindObjectOfType<UserInput>();
        //gameSaverScript = FindObjectOfType<GameSaver>();
        //setStarStatusScript = FindObjectOfType<SetStarStatus>();

        sceneName = SceneManager.GetActiveScene().name;
    }
 
    void Update ()
    {
        if(globalControlScript.deactivateMenu == false)
        {
            if(sceneButtonActive == true)
            {
                if (Input.GetMouseButton(0))
                {
                    if(changeSprite == true)
                    {
                        ChangeSprite ();
                    }
                }

                else if (Input.GetMouseButtonUp(0))
                {
                    sceneButtonActive = false;
                    //SaveLevelInfo();

                    pauseGame = FindObjectOfType<PauseGame>();
                    pauseGame.pauseAuto = false;
                    pauseGame.pauseManual = false;
                    SceneManager.LoadScene(sceneToLoad);
                }

            }
            //if (Input.GetMouseButtonDown(0))
            //{
            //    hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            //    //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y + ", " + hitShape.transform.position.z + "; HitShape Pos: " + hitShapePos);

            //    if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
            //    {
            //        ChangeSprite ();
            //    }
            //}

            //else if (Input.GetMouseButtonUp(0))
            //{
            //    hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            //    if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
            //    {
            //        ChangeSprite ();
            //        SaveLevelInfo();
            //        SceneManager.LoadScene(sceneToLoad);
            //    }
            //}
        }
    }


    private void ChangeSprite ()
    {
        if (spriteRenderer.sprite == buttonOut)
        {
            spriteRenderer.sprite = buttonIn;
        }
        else
        {
             spriteRenderer.sprite = buttonOut;
        }

        changeSprite = false;
    }


    //private void ChangeSprite ()
    //{
    //    if (this.transform.gameObject.name == hitShape.transform.gameObject.name && this.spriteRenderer.sprite == buttonOut)
    //    {
    //        this.spriteRenderer.sprite = buttonIn;
    //    }
    //    else
    //    {
    //         this.spriteRenderer.sprite = buttonOut;
    //    }

    //    changeSprite = false;
    //}

    //public void SaveLevelInfo()
    //{
    //    GameObject theTimer = GameObject.FindGameObjectWithTag("Timer");
    //    if(theTimer != null)
    //    {
    //        Timer timerScript = theTimer.GetComponent<Timer>();
    //    }
    //    //GlobalControl.Instance.timeLeftSave = timerScript.timeLeft;
    //    GlobalControl.Instance.scoreBalanceSave = counterScript.scoreTotalAmount;
    //    GlobalControl.Instance.coinsBalanceSave = counterScript.coinsTotalAmount;
    //    GlobalControl.Instance.matchesBalanceSave = userInputScript.shapesMatched.Count;
    //    HighScoreSave();
    //    HighCoinsSave();
    //    HighMatchesSave();
    //    if(setStarStatusScript != null)
    //    {
    //        StarCountSave();
    //    }
        

    //    PlayerPrefs.Save();

    //}

    //public void StarCountSave()
    //{
    //    if (setStarStatusScript.totalStarsEarned > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyStarsEarnedPerLevel))
    //    {
    //        PlayerPrefs.SetInt(sceneName + gameSaverScript.keyStarsEarnedPerLevel, setStarStatusScript.totalStarsEarned);
    //    }
    //}
    
    //public void HighScoreSave()
    //{
    //    if (counterScript.scoreTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighScoresPerLevel))
    //    {
    //        PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighScoresPerLevel, counterScript.scoreTotalAmount);
    //    }

    //    if (counterScript.scoreTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestScore))
    //    {
    //        PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestScore, counterScript.scoreTotalAmount);
    //    }
    //}

    //public void HighCoinsSave()
    //{
    //    if (counterScript.coinsTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighCoinsPerLevel))
    //    {
    //        PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighCoinsPerLevel, counterScript.coinsTotalAmount);
    //    }

    //    if (counterScript.coinsTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestCoin))
    //    {
    //        PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestCoin, counterScript.coinsTotalAmount);
    //    }
    //}

    //public void HighMatchesSave()
    //{
    //    if (counterScript.matchesTotalAmount > PlayerPrefs.GetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel))
    //    {
    //        PlayerPrefs.SetInt(sceneName + gameSaverScript.keyHighMatchesPerLevel, counterScript.matchesTotalAmount);
    //    }

    //    if (counterScript.matchesTotalAmount > PlayerPrefs.GetInt(gameSaverScript.keyAllTimeHighestMatch))
    //    {
    //        PlayerPrefs.SetInt(gameSaverScript.keyAllTimeHighestMatch, counterScript.matchesTotalAmount);
    //    }
    //}
}
