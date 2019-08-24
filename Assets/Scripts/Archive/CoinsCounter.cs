using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    public bool startCoinCounter = false;

    public int totalCoinBalance;
    private int coinsCounter = 0;

    public Text publicCoinsText;
    private CoinsCollected coinsCollectedScript;
    
    // Start is called before the first frame update
    void Start()
    {
        publicCoinsText = GetComponent<Text>();
        coinsCollectedScript = FindObjectOfType<CoinsCollected>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(startCoinCounter == true)
        {
            CountUpCoins();
        }
    }

    public void CountUpCoins()
    {
        if(coinsCollectedScript.onScreenCoinBalance < totalCoinBalance)
        {
            coinsCollectedScript.onScreenCoinBalance++;
            publicCoinsText.text = coinsCollectedScript.onScreenCoinBalance.ToString();
            //scoreCounter++;
        }

        else
        {
            startCoinCounter = false;
            //scoreToAdd = 0;
            //scoreCounter = 0;
        }
    }
}
