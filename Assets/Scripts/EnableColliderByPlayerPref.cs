using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColliderByPlayerPref : MonoBehaviour
{
    [SerializeField] string thisCityName;
    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel) == 1)
        {
            transform.gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            transform.gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
