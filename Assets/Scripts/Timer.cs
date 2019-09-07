using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {

    [SerializeField] public float timeLeft = 90f;

    [SerializeField] private GameObject resultsMenu;

    [SerializeField] private Vector2 menuPos;

    private bool timeUp = false;

    Text timeLeftText;
    private PauseGameStatus pauseGameScript;
    private ScoreBoard scoreBoardScript;

    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        pauseGameScript.pauseAuto = true;
        pauseGameScript.pauseManual = true;

        timeLeftText = GetComponent<Text>();
        timeLeftText.text = "1:30";

        timeUp = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(pauseGameScript.pauseManual == false)
        {
            AdjustTimeLeft();
        }

        if(timeLeft <= 0 && timeUp == false)
        {
            pauseGameScript.pauseAuto = true;
            pauseGameScript.pauseManual = true;
            LoadResultsMenu();
            timeUp = true;
        }
    }

    public void AdjustTimeLeft()
    {
        timeLeft = timeLeft - Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        
        if(timeLeft > 90f)
        {
            timeLeftText.text = "1:30";
        }

        else
        {
            timeLeftText.text = (Mathf.Floor(timeLeft / 60f)).ToString() + ":" + (Mathf.Floor(timeLeft % 60)).ToString();
        }
    }

    private void LoadResultsMenu()
    {
        Instantiate(resultsMenu, menuPos, Quaternion.identity);
    }
}
