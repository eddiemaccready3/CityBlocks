using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAcrossMap : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private Camera cam;

    private Vector3 mapLocation;
    private Vector3 mousePos;
    private Vector3 startMousePos;

    private float mapXOffset;
    private float mapYOffset;
    private float mapMoveX = 8000f;
    private float mapMoveXJumpLeft = 4000;
    private float mapMoveXJumpRight = -4000f;
    private float mapMoveY;
    private float mapMoveYTop;
    private float mapMoveYBottom;

    private float mousePosY;

    private float cameraWidth;
    private float cameraHeight;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mapLocation = map.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mapMoveYTop = -(2550f - (cameraHeight / 2));
        mapMoveYBottom = (2550f - (cameraHeight / 2));
        cameraHeight = cam.orthographicSize * 2f;
        cameraWidth = cam.aspect * cameraHeight;

        if(mousePosY + mapYOffset <= mapMoveYTop)
        {
            map.transform.position = new Vector2(mousePos.x + mapXOffset, mapMoveYTop);
        }
            
        if(mousePosY + mapYOffset >= mapMoveYBottom)
        {
            map.transform.position = new Vector2(mousePos.x + mapXOffset, mapMoveYBottom);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            mapLocation = map.transform.position;
            startMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePosY = mousePos.y;
            mapXOffset = mapLocation.x - startMousePos.x;
            mapYOffset = mapLocation.y - startMousePos.y;

            if(mousePosY + mapYOffset > mapMoveYTop && mousePosY + mapYOffset < mapMoveYBottom && mousePos.x + mapXOffset <= mapMoveXJumpLeft && mousePos.x + mapXOffset >= mapMoveXJumpRight)
            {
                map.transform.position = new Vector2(mousePos.x + mapXOffset, mousePosY + mapYOffset);
            }

            if(mousePos.x + mapXOffset >= mapMoveXJumpLeft)
            {
                map.transform.position = new Vector2(mousePos.x + mapXOffset - mapMoveX, map.transform.position.y);
            }

            if(mousePos.x + mapXOffset <= mapMoveXJumpRight)
            {
                map.transform.position = new Vector2(mousePos.x + mapXOffset + mapMoveX, map.transform.position.y);
            }
        }
    }
}
