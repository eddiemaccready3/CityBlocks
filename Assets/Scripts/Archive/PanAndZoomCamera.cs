using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAndZoomCamera : MonoBehaviour
{
    //Pan variables:
    [SerializeField] private GameObject map;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private GameObject startPosObject;

    [SerializeField] private float panMoveSpeed;

    private Vector2 mapLocation;
    private Vector2 camLocation;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    private Vector2 startPosObjectPos;

    private float camXOffset;
    private float camYOffset;
    private float camMoveX = 8000f;
    private float camMoveXJumpLeft = 4000;
    private float camMoveXJumpRight = -4000f;
    private float camMoveY;
    private float camMoveYTop;
    private float camMoveYBottom;

    private float mousePosY;

    private float cameraWidth;
    private float cameraHeight;

    //Zoom variables:
    [SerializeField] private float pinchZoomSpeed = 0.5f;        // The rate of change of the orthographic size by pinching.
    [SerializeField] private float scrollZoomSpeed = 10f;        // The rate of change of the orthographic size by scroll wheel.
    [SerializeField] private float minFov = 500f;
    [SerializeField] private float maxFov = 1000f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        camLocation = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Pan logic:
        camMoveYTop = -(2550f - (cameraHeight / 2));
        camMoveYBottom = (4100f - (cameraHeight / 2));
        cameraHeight = cam.orthographicSize * 2f;
        cameraWidth = cam.aspect * cameraHeight;

        

        if(mousePosY + camYOffset <= camMoveYTop)
        {
            cam.transform.position = new Vector2(mousePos.x - camXOffset, camMoveYTop);
        }
            
        if(mousePosY + camYOffset >= camMoveYBottom)
        {
            cam.transform.position = new Vector2(mousePos.x - camXOffset, camMoveYBottom);
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            camLocation = cam.transform.position;
            startMousePos = Input.mousePosition;
            //Instantiate(startPosObject, startMousePos, Quaternion.identity);
            //startPosObjectPos = startPosObject.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePosY = mousePos.y;
            camXOffset = camLocation.x - startMousePos.x;
            camYOffset = camLocation.y - startMousePos.y;

            if (mousePosY + camYOffset > camMoveYTop && mousePosY + camYOffset < camMoveYBottom && mousePos.x + camXOffset <= camMoveXJumpLeft && mousePos.x + camXOffset >= camMoveXJumpRight)
            {
                cam.transform.position = new Vector2((Mathf.Abs(startMousePos.x - mousePos.x) - mousePos.x) + camXOffset, mousePosY + camYOffset);
            }

            if (mousePos.x + camXOffset >= camMoveXJumpLeft)
            {
                cam.transform.position = new Vector2(mousePos.x + camXOffset - camMoveX, cam.transform.position.y);
            }

            if (mousePos.x + camXOffset <= camMoveXJumpRight)
            {
                cam.transform.position = new Vector2(mousePos.x + camXOffset + camMoveX, cam.transform.position.y);
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

        float orthoSize = cam.orthographicSize;
        float mapMenuScale;

        orthoSize += Input.GetAxis("Mouse ScrollWheel") * scrollZoomSpeed;
        orthoSize = Mathf.Clamp(orthoSize, minFov, maxFov);
        cam.orthographicSize = orthoSize;
    }
}
