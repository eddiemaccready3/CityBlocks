using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowObject : MonoBehaviour
{
    [SerializeField] private float finalSize;
    [SerializeField] private float growthSpeed;
    [SerializeField] private float startDelay;

    private float growthPerFrame;
    private float timeElapsed = 0;

    private bool growthComplete = false;
    
    // Update is called once per frame
    void Update()
    {
        if(growthComplete == false)
        {
            if(timeElapsed > startDelay)
            {
                growthPerFrame = growthSpeed * Time.deltaTime;

                if(transform.localScale.x < finalSize)
                {
                    Grow();
                }

                else
                {
                    growthComplete = true;
                }
            }

            timeElapsed += Time.deltaTime;
        }
    }

    private void Grow()
    {
        transform.localScale += new Vector3(growthPerFrame, growthPerFrame, 0f);
    }
}
