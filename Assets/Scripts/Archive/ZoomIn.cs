using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    [SerializeField] private float pinchZoomSpeed = 0.5f;        // The rate of change of the orthographic size by pinching.
    [SerializeField] private float scrollZoomSpeed = 10f;        // The rate of change of the orthographic size by scroll wheel.
    [SerializeField] private float minFov = 500f;
    [SerializeField] private float maxFov = 1000f;

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ... change the orthographic size based on the change in distance between the touches.
            cam.orthographicSize += deltaMagnitudeDiff * pinchZoomSpeed;

            // Make sure the orthographic size never drops below zero.
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minFov, maxFov);
        }

        else
        {
            float orthoSize = cam.orthographicSize;

            orthoSize += Input.GetAxis("Mouse ScrollWheel") * scrollZoomSpeed;
            orthoSize = Mathf.Clamp(orthoSize, minFov, maxFov);
            cam.orthographicSize = orthoSize;

            //print("Field of View: " + orthoSize);
        }
    }
}
