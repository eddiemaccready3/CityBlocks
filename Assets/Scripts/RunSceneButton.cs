﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSceneButton : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    [SerializeField] private string menuTagName;

    private GameObject[] menuObjects;
    
    private RaycastHit2D hitShape;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
        
            if(hitShape.collider != null)
            {
                hitShape.transform.gameObject.GetComponent<SceneButtonOnClick>().ButtonIn();
                hitShape.transform.gameObject.GetComponent<SceneButtonOnClick>().PlaySFX();
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
            if(hitShape.collider != null)
            {
                hitShape.transform.gameObject.GetComponent<SceneButtonOnClick>().ButtonOut();
                hitShape.transform.gameObject.GetComponent<SceneButtonOnClick>().RunButton();
            }
        }
    }
}
