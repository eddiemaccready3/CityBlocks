using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {

    [SerializeField] public float timeLeft = 60.0f;

    Text timeLeftText;
     // Use this for initialization
    void Start()
    {
        timeLeftText = GetComponent<Text>();
        timeLeftText.text = timeLeft.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        AdjustTimeLeft();

        //Debug.Log(timeLeft);
        //Debug.Log(Mathf.Round(timeLeft));

        //if (timeLeft <= 0)
        //{
        //    SceneManager.LoadScene("GameOver");
        //}
    }

    public void AdjustTimeLeft()
    {
        timeLeft = timeLeft - Time.deltaTime;
        timeLeftText.text = (Mathf.Round(timeLeft)).ToString();
    }
}
