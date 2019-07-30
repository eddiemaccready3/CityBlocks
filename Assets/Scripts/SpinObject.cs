using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] private float minSpinSpeed = 3600f;
    [SerializeField] private float maxSpinSpeed = 3600f;
    public float spinSpeed;

    [SerializeField] public float markerRotationAngle;

    public bool rotateMarker = false;

    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = Random.Range (minSpinSpeed, maxSpinSpeed);
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
        markerRotationAngle -= (spinSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, markerRotationAngle);
    }
}
