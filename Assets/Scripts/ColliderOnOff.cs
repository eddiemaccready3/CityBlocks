using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOnOff : MonoBehaviour
{
    [SerializeField] private string cityName;

    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(cityName + gameSaverScript.keyPlaneFlightCompletedPerLevel) == 1)
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
