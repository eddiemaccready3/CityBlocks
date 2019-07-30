using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementCurve : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 0.92f;
    [SerializeField] private float startRotationAngle;

    private float rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = startRotationAngle;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        rotationAngle = rotationAngle * spinSpeed;
    }
}
