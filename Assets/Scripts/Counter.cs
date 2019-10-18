using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public bool startAddingScore;
    public bool startAddingCoins;

    public int coinsCurrentAmount;
    public int scoreCurrentAmount;
    public int coinsTotalAmount;
    public int scoreTotalAmount;
    public int matchesCurrentAmount;
    public int matchesTotalAmount;
    private int amountToAdd;

    private Text amountTextName;

    private ScoreBoard scoreBoardScript;

    [SerializeField] public Text scoreBalanceText;
    [SerializeField] public Text coinsBalanceText;
    //[SerializeField] public Text matchesBalanceText;

    private List<string> shapesMatched = new List<string>();

    private void Start()
    {
        //scoreTotalAmount = GlobalControl.Instance.scoreBalanceSave;
        scoreTotalAmount = 0;
        scoreCurrentAmount = scoreTotalAmount;
        scoreBalanceText.text = scoreCurrentAmount.ToString();

        //coinsTotalAmount = GlobalControl.Instance.coinsBalanceSave;
        coinsTotalAmount = 0;
        coinsCurrentAmount = coinsTotalAmount;
        coinsBalanceText.text = coinsCurrentAmount.ToString();

        //matchesTotalAmount = GlobalControl.Instance.matchesBalanceSave;
        //matchesCurrentAmount = matchesTotalAmount;
        //matchesBalanceText.text = matchesCurrentAmount.ToString();

        scoreBoardScript = FindObjectOfType<ScoreBoard>();

        shapesMatched.Clear();
    }

    private void FixedUpdate()
    {
        if(startAddingScore == true)
        {
            ScoreCounter();
            //scoreBoardScript.ScoreHit();
        }

        if(startAddingCoins == true)
        {
            CoinsCounter();
        }
    }

    private void ScoreCounter()
    {
        if (scoreCurrentAmount < scoreTotalAmount)
        {
            scoreCurrentAmount += 25;
            scoreBalanceText.text = scoreCurrentAmount.ToString();
        }

        else
        {
            startAddingScore = false;
            //scoreCurrentAmount = scoreTotalAmount;
            //scoreBalanceText.text = scoreCurrentAmount.ToString();
        }
    }
    
    private void CoinsCounter()
    {
        if (coinsCurrentAmount < coinsTotalAmount)
        {
            coinsCurrentAmount++;
            coinsBalanceText.text = coinsCurrentAmount.ToString();
        }

        else
        {
            startAddingCoins = false;
            //coinsCurrentAmount = coinsTotalAmount;
            //coinsBalanceText.text = coinsCurrentAmount.ToString();
        }
    }

    public void AddInAmount(int inputAmountToAdd, string balanceName)
    {
        amountToAdd = inputAmountToAdd;

        if(balanceName == "score")
        {
            scoreTotalAmount += amountToAdd;
        }

        if(balanceName == "coins")
        {
            coinsTotalAmount += amountToAdd;
        }
    }
}
