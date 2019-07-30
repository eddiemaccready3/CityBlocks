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
    private PauseGame pauseGameScript;
    private ScoreBoard scoreBoardScript;

    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGame>();
        timeLeftText = GetComponent<Text>();
        timeLeftText.text = timeLeft.ToString();
        //timeLeft = GlobalControl.Instance.timeLeftSave;
        scoreBoardScript = FindObjectOfType<ScoreBoard>();

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
            //scoreBoardScript.SaveLevelInfo();
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
        timeLeftText.text = (Mathf.Round(timeLeft)).ToString();
    }

    private void LoadResultsMenu()
    {
        Instantiate(resultsMenu, menuPos, Quaternion.identity);
    }
}
