using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollected : MonoBehaviour
{
    public int onScreenCoinBalance;
    private Text coinText;

    public int coinBalanceSave;
   
     // Use this for initialization
        
    void Start()
    {
        onScreenCoinBalance = GlobalControl.Instance.coinsBalanceSave;
        coinText = GetComponent<Text>();
        coinText.text = onScreenCoinBalance.ToString();
    }
}
