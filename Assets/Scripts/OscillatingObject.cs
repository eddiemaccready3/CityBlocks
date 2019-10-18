using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingObject : MonoBehaviour
{
    [SerializeField] private float totalDistance;
    [SerializeField] private float moveSpeed;

    private Vector2 startingPos;
    private Vector2 currentPos;

    private bool moveLeft;
    private bool moveRight;

    private float movePerFrame;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        moveRight = true;

        movePerFrame = moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        movePerFrame = moveSpeed * Time.deltaTime;
        
        currentPos = transform.position;

        if (moveRight == true)
        {
            if(currentPos.x < startingPos.x + totalDistance)
            {
                transform.position = new Vector2(currentPos.x + movePerFrame, currentPos.y);
            }

            else
            {
                moveRight = false;
                moveLeft = true;
            }
        }

        if (moveLeft == true)
        {
            if(currentPos.x > startingPos.x)
            {
                transform.position = new Vector2(currentPos.x - movePerFrame, currentPos.y);
            }

            else
            {
                moveLeft = false;
                moveRight = true;
            }
        }
    }
}
