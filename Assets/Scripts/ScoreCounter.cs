using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public bool startScoreCounter = false;

    public int scoreToAdd;
    public int totalScore;

    private int scoreCounter = 0;

    public Text publicScoreText;
    private ScoreBoard scoreBoardScript;
    
    // Start is called before the first frame update
    void Start()
    {
        publicScoreText = GetComponent<Text>();
        scoreBoardScript = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(startScoreCounter == true)
        {
            CountUpScore();
        }
    }

    public void CountUpScore()
    {
        if(scoreBoardScript.score < totalScore)
        {
            scoreBoardScript.score++;
            publicScoreText.text = scoreBoardScript.score.ToString();
            //scoreCounter++;
        }

        else
        {
            startScoreCounter = false;
            //scoreToAdd = 0;
            //scoreCounter = 0;
        }
    }
}
