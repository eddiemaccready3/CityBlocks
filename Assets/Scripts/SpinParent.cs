using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinParent : MonoBehaviour
{
    public float spinSpeed;

    [SerializeField] private float markerRotationAngle;

    public bool rotateMarker = true;

    private SpinObject spinObjectScript;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, markerRotationAngle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rotateMarker == true)
        {
            RotateMarker();
        }
    }

    public void RotateMarker()
    {
        spinObjectScript = GetComponentInChildren<SpinObject>();
        spinSpeed = spinObjectScript.spinSpeed;
        markerRotationAngle -= (spinSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, markerRotationAngle);
    }
}
