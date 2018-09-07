using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement : MonoBehaviour {

    private float zRotationLeft = 0;
    private float zRotationMiddle = 0;
    private float zRotationRight = 0;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hitShape != null && hitShape.collider != null && hitShape.transform.position.y < 0f && hitShape.transform.position.x < 2f && hitShape.transform.gameObject.layer == 11)
            {
                zRotationLeft = zRotationLeft + 90;
                hitShape.transform.rotation = Quaternion.Euler(0f, 0f, zRotationLeft);

            }

            else if(hitShape != null && hitShape.collider != null && hitShape.transform.position.y < 0f && hitShape.transform.position.x > 2f && hitShape.transform.position.x < 5f && hitShape.transform.gameObject.layer == 11)
            {
                zRotationMiddle = zRotationMiddle + 90;
                hitShape.transform.rotation = Quaternion.Euler(0f, 0f, zRotationMiddle);
            }

            else if(hitShape != null && hitShape.collider != null && hitShape.transform.position.y < 0f && hitShape.transform.position.x > 5f && hitShape.transform.gameObject.layer == 11)
            {
                zRotationRight = zRotationRight + 90;
                hitShape.transform.rotation = Quaternion.Euler(0f, 0f, zRotationRight);
            }
        }
    }
}