using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInText : MonoBehaviour
{
    [SerializeField] private float durationOfFadeIn;
    [SerializeField] private float fadeStartTime;
    private float timeOfInitialization;

    private float minimum = 0f;
    private float maximum = 1f;

    private Text text;

    private Outline outline;

    private Color fadingColor;
    private Color fadingOutlineColor;

	// Use this for initialization
	void Start ()
    {
        timeOfInitialization = Time.time;
        text = GetComponent<Text>();
        outline = GetComponent<Outline>();
        SetTextAlpha(0);
    }

    private void SetTextAlpha(float alpha)
    {
        fadingColor = text.color;
        fadingColor.a = alpha;
        text.color = fadingColor;

        if(outline != null)
        {
            fadingOutlineColor = outline.effectColor;
            fadingOutlineColor.a = alpha;
            outline.effectColor = fadingOutlineColor;
        }
    }

    // Update is called once per frame
    void Update () {
        if(Time.time > timeOfInitialization + fadeStartTime)
        {
            float t = (Time.time - (timeOfInitialization + fadeStartTime)) / durationOfFadeIn;
            SetTextAlpha(Mathf.SmoothStep(minimum, maximum, t));
        }
	}
}
