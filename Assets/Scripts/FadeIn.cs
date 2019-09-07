using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private float durationOfFadeIn;
    [SerializeField] private float fadeStartTime;
    private float timeOfInitialization;

    private float minimum = 0f;
    private float maximum = 1f;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        timeOfInitialization = Time.time;
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 0);
    }

    // Update is called once per frame
    void Update () {
        if(Time.time > timeOfInitialization + fadeStartTime)
        {
            float t = (Time.time - (timeOfInitialization + fadeStartTime)) / durationOfFadeIn;
            sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
        }
	}
}
