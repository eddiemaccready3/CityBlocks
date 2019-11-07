using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class MoveCameraToContinent : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private Vector3 cameraStartPos;
    [SerializeField] private Vector3 cameraEndPos;
    [SerializeField] private float cameraStartZoom;
    [SerializeField] private float cameraEndZoom;

    private float totalXDistStartToEnd;
    private float totalYDistStartToEnd;
    private float camXPerFrameMoveDist;
    private float camYPerFrameMoveDist;
    private float camPerFrameZoomChange;
    private float orthoSize;
    private float newXPosEachFrame;
    private float newYPosEachFrame;

    private int xMoveDirection;
    private int yMoveDirection;

    private bool cameraMoved = false;

    private PlaneMovement planeMovementScript;
    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        planeMovementScript = FindObjectOfType<PlaneMovement>();
        gameSaverScript = FindObjectOfType<GameSaver>();
        
        totalXDistStartToEnd = TrigFunctions.FindDistance(cameraStartPos.x, cameraEndPos.x);
        totalYDistStartToEnd = TrigFunctions.FindDistance(cameraStartPos.y, cameraEndPos.y);

        if(planeMovementScript != null)
        {
            camXPerFrameMoveDist = planeMovementScript.xPerFrameMoveDistance;
            camYPerFrameMoveDist = (planeMovementScript.xPerFrameMoveDistance * totalYDistStartToEnd) / totalXDistStartToEnd;
        }

        newXPosEachFrame = cam.transform.position.x + camXPerFrameMoveDist;
        newYPosEachFrame = cam.transform.position.y + camYPerFrameMoveDist;

        xMoveDirection = SetMoveDirection(cameraStartPos.x, cameraEndPos.x);
        yMoveDirection = SetMoveDirection(cameraStartPos.y, cameraEndPos.y);

        orthoSize = cameraStartZoom;
    }

    private int SetMoveDirection(float previousMarkerPos, float thisMarkerPos)
    {
        if(previousMarkerPos > thisMarkerPos)
        {
            return -1;
        }

        else
        {
            return 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(planeMovementScript != null)
        {
            if(planeMovementScript.moveCamera == true)
            {
                PlayerPrefs.SetInt(gameSaverScript.keyEndEuropeMapZoom, 2);
                //camXPerFrameMoveDist = planeMovementScript.xPerFrameMoveDistance;
                //camYPerFrameMoveDist = (planeMovementScript.xPerFrameMoveDistance * totalYDistStartToEnd) / totalXDistStartToEnd;

                //camPerFrameZoomChange = ((cameraEndZoom - cameraStartZoom) / totalXDistStartToEnd) * camXPerFrameMoveDist;

                //newXPosEachFrame = cam.transform.position.x + (camXPerFrameMoveDist * xMoveDirection);
                //newYPosEachFrame = cam.transform.position.y + (camYPerFrameMoveDist * yMoveDirection);
        
                //if(cameraMoved == false)
                //{
                //    if(cam.transform.position.x < cameraEndPos.x)
                //    {
                //        cam.transform.position = new Vector2(newXPosEachFrame, newYPosEachFrame);
                //        orthoSize += camPerFrameZoomChange;
                //        cam.orthographicSize = orthoSize;
                //    }
                //    else
                //    {
                //        cam.transform.position = new Vector2(cameraEndPos.x, cameraEndPos.y);
                //        cameraMoved = true;
                //    }
                //}
            }
        }
    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Assets;

//public class MoveCameraToContinent : MonoBehaviour
//{
//    [SerializeField] private GameObject map;
//    [SerializeField] private Camera cam;

//    [SerializeField] private Vector3 cameraStartPos;
//    [SerializeField] private Vector3 cameraEndPos;
//    [SerializeField] private float cameraStartZoom;
//    [SerializeField] private float cameraEndZoom;

//    private float totalXDistStartToEnd;
//    private float totalYDistStartToEnd;
//    private float camXPerFrameMoveDist;
//    private float camYPerFrameMoveDist;
//    private float camPerFrameZoomChange;
//    private float orthoSize;
//    private float newXPosEachFrame;
//    private float newYPosEachFrame;

//    private int xMoveDirection;
//    private int yMoveDirection;

//    private bool cameraMoved = false;

//    private PlaneMovementStatic planeMovementStaticScript;
    
//    // Start is called before the first frame update
//    void Start()
//    {
//        cameraStartPos = map.transform.position;
//        planeMovementStaticScript = FindObjectOfType<PlaneMovementStatic>();
        
//        totalXDistStartToEnd = TrigFunctions.FindDistance(cameraStartPos.x, cameraEndPos.x);
//        totalYDistStartToEnd = TrigFunctions.FindDistance(cameraStartPos.y, cameraEndPos.y);

//        if(planeMovementStaticScript != null)
//        {
//            camXPerFrameMoveDist = planeMovementStaticScript.xPerFrameMoveDistance;
//            camYPerFrameMoveDist = (planeMovementStaticScript.xPerFrameMoveDistance * totalYDistStartToEnd) / totalXDistStartToEnd;
//        }

//        newXPosEachFrame = map.transform.position.x + camXPerFrameMoveDist;
//        newYPosEachFrame = map.transform.position.y + camYPerFrameMoveDist;

//        xMoveDirection = SetMoveDirection(cameraStartPos.x, cameraEndPos.x);
//        yMoveDirection = SetMoveDirection(cameraStartPos.y, cameraEndPos.y);

//        orthoSize = cameraStartZoom;
//    }

//    private int SetMoveDirection(float previousMarkerPos, float thisMarkerPos)
//    {
//        if(previousMarkerPos > thisMarkerPos)
//        {
//            return -1;
//        }

//        else
//        {
//            return 1;
//        }
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        if(planeMovementStaticScript != null)
//        {
//            if(planeMovementStaticScript.moveCamera == true)
//            {
//                camXPerFrameMoveDist = planeMovementStaticScript.xPerFrameMoveDistance;
//                camYPerFrameMoveDist = (planeMovementStaticScript.xPerFrameMoveDistance * totalYDistStartToEnd) / totalXDistStartToEnd;

//                camPerFrameZoomChange = ((cameraEndZoom - cameraStartZoom) / totalXDistStartToEnd) * camXPerFrameMoveDist;

//                newXPosEachFrame = map.transform.position.x + (camXPerFrameMoveDist * xMoveDirection);
//                newYPosEachFrame = map.transform.position.y + (camYPerFrameMoveDist * yMoveDirection);
        
//                if(cameraMoved == false)
//                {
//                    if(map.transform.position.x > cameraEndPos.x)
//                    {
//                        map.transform.position = new Vector2(newXPosEachFrame, newYPosEachFrame);
//                        orthoSize += camPerFrameZoomChange;
//                        cam.orthographicSize = orthoSize;
//                    }
//                    else
//                    {
//                        map.transform.position = new Vector2(cameraEndPos.x, cameraEndPos.y);
//                        cameraMoved = true;
//                    }
//                }
//            }
//        }
//    }
//}