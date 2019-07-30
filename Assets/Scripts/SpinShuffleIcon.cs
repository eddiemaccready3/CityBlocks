using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShuffleIcon : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 0.92f;
    [SerializeField] private float startRotationAngle = 3600f;

    [SerializeField] private Vector3 hitShapePos;

    private float rotationAngle;

    public bool rotate = false;

    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = startRotationAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hitShape.collider != null && rotationAngle == startRotationAngle && hitShape.transform.position == hitShapePos)
            {
                rotate = true;
            }
        }

        RotateButton();
    }

    private void RotateButton()
    {
        if (rotate)
        {
            Rotate();
        }
    }

    public void Rotate()
    {
        if (rotationAngle > 1)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
            rotationAngle = rotationAngle * spinSpeed;
        }

        else
        {
            rotate = false;
            rotationAngle = startRotationAngle;
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
    }
}
