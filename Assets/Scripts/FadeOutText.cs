using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutText : MonoBehaviour
{
    [SerializeField] public float durationOfFadeOut;
    [SerializeField] public float fadeStartTime;
    private float timeOfInitialization;

    private float minimum = 0f;
    private float maximum = 1f;

    private Text text;

    private Outline outline;

	// Use this for initialization
	void Start ()
    {
        timeOfInitialization = Time.time;
        text = GetComponent<Text>();
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update () {
        if(Time.time > timeOfInitialization + fadeStartTime)
        {
            float t = (Time.time - (timeOfInitialization + fadeStartTime)) / durationOfFadeOut;
            Color fadingColor = text.color;
            fadingColor.a = Mathf.SmoothStep(maximum, minimum, t);
            text.color = fadingColor;

            if(outline != null)
            {
                Color fadingOutlineColor = outline.effectColor;
                fadingOutlineColor.a = Mathf.SmoothStep(maximum, minimum, t);
                outline.effectColor = fadingOutlineColor;
            }
        }
	}
}
