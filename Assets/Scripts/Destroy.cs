using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private float xPos;
    private float yPos;
    private float initialXPos;
    private float initialYPos;

    private Vector2 tempMoveUp;
    private Vector2 tempMoveRight;

    private bool destroyOn = true;

    private void Start()
    {
        initialXPos = gameObject.transform.position.x;
        initialYPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
        yPos = gameObject.transform.position.y;
    }

    private void SetDestroyOn()
    {
        if (initialYPos == yPos)
        {
            destroyOn = true;
        }
        else
        {
            destroyOn = false;
        }
    }

    private void MoveRight()
    {
        gameObject.transform.position = tempMoveRight;
        Destroy(gameObject);
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        

        tempMoveUp = new Vector2 (xPos, yPos + 1);
        tempMoveRight = new Vector2 (xPos + 10f, yPos);
        if (destroyOn)
        {    
            if (other)
            {
                if (destroyOn)
                {
                    Destroy(other.gameObject);
                }
                gameObject.transform.position = tempMoveUp;
                Invoke("MoveRight", 0.05f);

                xPos = gameObject.transform.position.x;
                yPos = gameObject.transform.position.y;

                SetDestroyOn();
            }
        }
    }
}
