using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBangkokMarkerStatus : MonoBehaviour
{
    [SerializeField] private string padlockName;
    
    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(padlockName + gameSaverScript.keyPointsStarEarnedPerLevel) == 0)
        {
            GameObject.Find("BangkokMarker").GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            GameObject.Find("BangkokMarker").GetComponent<Collider2D>().enabled = true;
        }
    }
}
