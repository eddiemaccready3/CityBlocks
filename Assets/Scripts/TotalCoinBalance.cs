using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinBalance : MonoBehaviour
{
    [SerializeField] private Text totalCoinBalance;

    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();

        totalCoinBalance.text = PlayerPrefs.GetInt(gameSaverScript.keyTotalCoinBalance).ToString();
    }
}
