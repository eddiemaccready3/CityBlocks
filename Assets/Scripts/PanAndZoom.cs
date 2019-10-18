using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAndZoom : MonoBehaviour
{
    //Pan variables:
    [SerializeField] private GameObject map;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject mapMenu;

    private Vector2 mapLocation;
    private Vector2 mousePos;
    private Vector2 startMousePos;

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

    //Zoom variables:
    [SerializeField] private float pinchZoomSpeed = 0.25f;        // The rate of change of the orthographic size by pinching.
    [SerializeField] private float scrollZoomSpeed = 5f;        // The rate of change of the orthographic size by scroll wheel.
    [SerializeField] private float minFov = 570f;
    [SerializeField] private float maxFov = 1200f;
    
    private PauseGameStatus pauseGameScript;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        mapLocation = map.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGameScript.pauseAuto == false || pauseGameScript.pauseManual == false)
        {
            //Pan logic:
            mapMoveYTop = -(2550f - (cameraHeight / 2));
            mapMoveYBottom = (4100f - (cameraHeight / 2));
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

                if (mousePosY + mapYOffset > mapMoveYTop && mousePosY + mapYOffset < mapMoveYBottom && mousePos.x + mapXOffset <= mapMoveXJumpLeft && mousePos.x + mapXOffset >= mapMoveXJumpRight)
                {
                    map.transform.position = new Vector2(mousePos.x + mapXOffset, mousePosY + mapYOffset);
                }

                if (mousePos.x + mapXOffset >= mapMoveXJumpLeft)
                {
                    map.transform.position = new Vector2(mousePos.x + mapXOffset - mapMoveX, map.transform.position.y);
                }

                if (mousePos.x + mapXOffset <= mapMoveXJumpRight)
                {
                    map.transform.position = new Vector2(mousePos.x + mapXOffset + mapMoveX, map.transform.position.y);
                }
            }


            //Zoom logic:
            // If there are two touches on the device...
            if (Input.touchCount == 2)
            {
                // Store both touches.
                Touch zoomTouchZero = Input.GetTouch(0);
                Touch zoomTouchOne = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touchZeroPrevPos = zoomTouchZero.position - zoomTouchZero.deltaPosition;
                Vector2 touchOnePrevPos = zoomTouchOne.position - zoomTouchOne.deltaPosition;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (zoomTouchZero.position - zoomTouchOne.position).magnitude;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                // ... change the orthographic size based on the change in distance between the touches.
                cam.orthographicSize += deltaMagnitudeDiff * pinchZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minFov, maxFov);
            }

            //else
            //{
            float orthoSize = cam.orthographicSize;
            float mapMenuScale;

            orthoSize += Input.GetAxis("Mouse ScrollWheel") * scrollZoomSpeed;
            orthoSize = Mathf.Clamp(orthoSize, minFov, maxFov);
            cam.orthographicSize = orthoSize;
        }
    }
}