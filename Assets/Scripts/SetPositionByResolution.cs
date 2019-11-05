using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionByResolution : MonoBehaviour
{
    [SerializeField] private float higherPosition = 9.82f;
    [SerializeField] private float lowerPosition = 11.4f;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(cam.aspect < 0.5625)
        {
            transform.position = new Vector3(transform.position.x, lowerPosition, 0f);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, higherPosition, 0f);
        }
    }
}
