using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    [SerializeField] private float delay;

    [SerializeField] private float minimum = 0.0f;
    [SerializeField] private float maximum = 1f;
    [SerializeField] private float duration = 5.0f;
    [SerializeField] private float startTime;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;
        Invoke("DestroySelfGO", delay);
        sprite = GetComponent<SpriteRenderer>();
    }

    private void DestroySelfGO()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(maximum, minimum, t));
		
	}
}
