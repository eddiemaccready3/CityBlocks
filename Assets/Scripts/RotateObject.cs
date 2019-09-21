using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float totalDegOfRotation;
    [SerializeField] private float startDelay;
    [SerializeField] private float speed;

    private float degreesRotated = 0;
    private float timeElapsed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed > startDelay)
        {
            degreesRotated += (speed * Time.deltaTime);

            if(degreesRotated < totalDegOfRotation)
            {
                Rotate();
            }

            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, totalDegOfRotation);
            }
        }

        timeElapsed += Time.deltaTime;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, degreesRotated);
    }
}
