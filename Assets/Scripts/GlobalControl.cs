using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public bool deactivateMenu = false;
    
    public static GlobalControl Instance;

    private ScoreBoard scoreboardScript;

    public float timeLeftSave = 90f;
    public int scoreBalanceSave;
    public int coinsBalanceSave;
    public int matchesBalanceSave;

    private void Start()
    {
        scoreboardScript = FindObjectOfType<ScoreBoard>();
        
    }

    void Awake ()   
        {
        if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy (gameObject);
            }
        }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            scoreboardScript.HighScoreSave();
            PlayerPrefs.Save();
            Application.Quit();
        }

        if (Input.GetKey("backspace"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
