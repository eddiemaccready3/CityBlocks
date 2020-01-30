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
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;

    [SerializeField] private string tagName;

    [SerializeField] private LayerMask layer;

    [SerializeField] private GameObject arrow;

    [SerializeField] AudioClip audioClip;

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

    private bool moveCamera = false;
    private bool zoomCamera = false;

    private RaycastHit2D hitShape;

    AudioSource audioSource;

    private PlaneMovement planeMovementScript;
    private GameSaver gameSaverScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        
        orthoSize = cameraStartZoom;

        audioSource = GetComponent<AudioSource>();
    }

    private int SetMoveDirection(float startCamPos, float endCamPos)
    {
        if(startCamPos > endCamPos)
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
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            if(hitShape.collider != null && hitShape.transform.gameObject == arrow && hitShape.transform.gameObject.tag == tagName)
            {
                PlaySound(audioClip);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            if(hitShape.collider != null && hitShape.transform.gameObject == arrow && hitShape.transform.gameObject.tag == tagName)
            {
                SetMoveDistances();
                orthoSize = cameraStartZoom;
                moveCamera = true;
            }
        }
        
        if(moveCamera == true)
        {
            CameraMovement();
        }
    }

    private void CameraMovement()
    {
        newXPosEachFrame = cam.transform.position.x + camXPerFrameMoveDist;
        newYPosEachFrame = cam.transform.position.y + camYPerFrameMoveDist;
        if (SetMoveDirection(cameraStartPos.x, cameraEndPos.x) == 1)
        {
            if ((cam.transform.position.x + camXPerFrameMoveDist) < cameraEndPos.x)
            {
                cam.transform.position = new Vector3(newXPosEachFrame, newYPosEachFrame, -10f);
                SetCameraZoom();
            }

            else if((cam.transform.position.x + camXPerFrameMoveDist) > cameraEndPos.x)
            {
                cam.transform.position = new Vector3(cameraEndPos.x, cameraEndPos.y, -10f);
                cam.orthographicSize = cameraEndZoom;
                moveCamera = false;
            }
        }

        else if(SetMoveDirection(cameraStartPos.x, cameraEndPos.x) == -1)
        {
            if ((cam.transform.position.x + camXPerFrameMoveDist) > cameraEndPos.x)
            {
                cam.transform.position = new Vector3(newXPosEachFrame, newYPosEachFrame, -10f);
                SetCameraZoom();
            }

            else if((cam.transform.position.x + camXPerFrameMoveDist) < cameraEndPos.x)
            {
                cam.transform.position = new Vector3(cameraEndPos.x, cameraEndPos.y, -10f);
                cam.orthographicSize = cameraEndZoom;
                moveCamera = false;
            }
        }
    }

    private void SetCameraZoom()
    {
        if (cameraStartZoom > cameraEndZoom)
        {
            if (cam.orthographicSize > cameraEndZoom)
            {
                orthoSize -= Mathf.Abs(((camXPerFrameMoveDist / totalXDistStartToEnd) * (Mathf.Abs(cameraStartZoom - cameraEndZoom))));
                cam.orthographicSize = orthoSize;
            }
            else if(cam.orthographicSize < cameraEndZoom)
            {
                cam.orthographicSize = cameraEndZoom;
            }
        }
        else
        {
            if (cam.orthographicSize < cameraEndZoom)
            {
                orthoSize += Mathf.Abs(((camXPerFrameMoveDist / totalXDistStartToEnd) * (Mathf.Abs(cameraStartZoom - cameraEndZoom))));
                cam.orthographicSize = orthoSize;
            }
            else if(cam.orthographicSize > cameraEndZoom)
            {
                cam.orthographicSize = cameraEndZoom;
            }
        }
    }

    private void SetMoveDistances()
    {
        totalXDistStartToEnd = TrigFunctions.FindDistance(cameraStartPos.x, cameraEndPos.x);
        totalYDistStartToEnd = TrigFunctions.FindDistance(cameraStartPos.y, cameraEndPos.y);

        camXPerFrameMoveDist = (totalXDistStartToEnd / moveSpeed) * Time.deltaTime * SetMoveDirection(cameraStartPos.x, cameraEndPos.x);
        camYPerFrameMoveDist = (totalYDistStartToEnd / moveSpeed) * Time.deltaTime * SetMoveDirection(cameraStartPos.y, cameraEndPos.y);
    }

    private void PlaySound(AudioClip sound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(sound);
        }
    }
}