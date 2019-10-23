using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockingObject : MonoBehaviour
{
    [SerializeField] private float totalAngle;
    [SerializeField] private float rockSpeed;

    private float startingRot;
    private float currentRot;

    private bool rockLeft;
    private bool rockRight;

    private float anglePerFrame;
    
    // Start is called before the first frame update
    void Start()
    {
        startingRot = transform.rotation.z;
        rockRight = true;

        anglePerFrame = rockSpeed * Time.deltaTime;

        currentRot = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        anglePerFrame = rockSpeed * Time.deltaTime;

        if (rockRight == true)
        {
            if(currentRot > (startingRot - (totalAngle / 2)))
            {
                currentRot -= anglePerFrame;
                transform.rotation = Quaternion.Euler(0f, 0f, currentRot);
            }

            else
            {
                rockRight = false;
                rockLeft = true;
            }
        }

        if (rockLeft == true)
        {
            if(currentRot < (startingRot + (totalAngle / 2)))
            {
                currentRot += anglePerFrame;
                transform.rotation = Quaternion.Euler(0f, 0f, currentRot);
            }

            else
            {
                rockLeft = false;
                rockRight = true;
            }
        }
    }
}
