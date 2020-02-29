using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour
{
    [SerializeField] private bool maintainWidth = true;
    [SerializeField] private Camera cam;
    [SerializeField] private float adaptPosition = -3.38f;

    [SerializeField] private GameObject backgroundSprite;

    private float defaultWidth;
    private float defaultHeight;

    private float spriteWidth;


    private Vector3 cameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = cam.transform.position;
        
        defaultHeight = cam.orthographicSize;
        defaultWidth = cam.orthographicSize * cam.aspect;
       //print("cam.aspect: " + cam.aspect);
    }

    // Update is called once per frame
    void Update()
    {
       //print("cam.aspect: " + cam.aspect);
        if(maintainWidth == true)
        {
            cam.orthographicSize = ((backgroundSprite.GetComponent<Renderer>().bounds.size.x) / 2f) / cam.aspect;
            //cam.transform.position = new Vector3(backgroundSprite.transform.position.x, backgroundSprite.transform.position.y, -10f);
            
            //cam.orthographicSize = defaultWidth / cam.aspect;

            cam.transform.position = new Vector3(cameraPos.x, adaptPosition + cam.orthographicSize, -10f);
        }
    }
}
