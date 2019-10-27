using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private GameObject dot;
    [SerializeField] private GameObject line;
    private GameObject [] drawObjects;
    
    private Vector3 currentMousePos;
    private Vector2 currentWorldMousePos;
    private Vector3 lastMousePos;
    private Vector3 lastWorldMousePos;
    private Vector3 camDistanceCorrection = new Vector3 (0, 0, 10);
    private Vector3 centerPosition;

    private bool firstPoint = true;

    private PauseGameStatus pauseGameScript;

    private List<float> xPostions = new List<float>();
    private List<float> yPostions = new List<float>();

    private float distanceDotToDot;
    private float xDistance;
    private float xMin;
    private float yDistance;
    private float xMax;
    private float yMin;
    private float yMax;
    private float angle;

    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        pauseGameScript = FindObjectOfType<PauseGameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseGameScript.pauseAuto == false)
        {
            if (Input.GetMouseButton(0))
            {
                InitiateStartingXYValues();
                PopulateMinMaxXYValues();
                InstantiateFirstDot();
                LineDrawer();
                SaveLastXYPositions();
            }

            if (Input.GetMouseButtonUp(0))
            {
                DeleteLine();
            }
        }
    }

    private void DeleteLine()
    {
        drawObjects = GameObject.FindGameObjectsWithTag("Draw");
        for (var i = 0; i < drawObjects.Length; i++)
        {
            Destroy(drawObjects[i]);
        }
        firstPoint = true;
    }

    private void SaveLastXYPositions()
    {
        lastMousePos = currentMousePos;
        lastWorldMousePos = cam.ScreenToWorldPoint(lastMousePos);

        xPostions.Add(lastWorldMousePos.x);
        yPostions.Add(lastWorldMousePos.y);
        firstPoint = false;
    }

    private void InstantiateFirstDot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(dot, cam.ScreenToWorldPoint(currentMousePos + camDistanceCorrection), Quaternion.identity);
        }
    }

    private void InitiateStartingXYValues()
    {
        currentMousePos = Input.mousePosition;
        currentWorldMousePos = cam.ScreenToWorldPoint(currentMousePos);


        if (firstPoint == true)
        {
            lastMousePos = currentMousePos;
            lastWorldMousePos = currentWorldMousePos;
            xPostions.Clear();
            yPostions.Clear();
            xPostions.Add(lastWorldMousePos.x);
            yPostions.Add(lastWorldMousePos.y);
        }

        xPostions.Add(currentWorldMousePos.x);
        yPostions.Add(currentWorldMousePos.y);
    }

    private void PopulateMinMaxXYValues()
    {
        if (xPostions != null && yPostions != null)
        {
            xMin = xPostions.Min();
            xMax = xPostions.Max();
            yMin = yPostions.Min();
            yMax = yPostions.Max();
        }
    }

    private void LineDrawer()
    {
        if (currentMousePos != lastMousePos)
        {
            angle = Mathf.Atan2(currentMousePos.y - lastMousePos.y, currentMousePos.x - lastMousePos.x);
            xDistance = Mathf.Abs(currentWorldMousePos.x - lastWorldMousePos.x);
            yDistance = Mathf.Abs(currentWorldMousePos.y - lastWorldMousePos.y);
            distanceDotToDot = Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2));
            Instantiate(dot, cam.ScreenToWorldPoint(currentMousePos + camDistanceCorrection), Quaternion.identity, transform);
            centerPosition = new Vector3((xDistance / 2) + xMin, (yDistance / 2) + yMin, 0);
            GameObject newLine = Instantiate(line, centerPosition, Quaternion.identity, transform) as GameObject;
            newLine.transform.localScale = new Vector3(distanceDotToDot / 0.4f, 1, 1);
            newLine.transform.localRotation = Quaternion.Euler(0, 0, (angle * (180 / Mathf.PI)));
            xPostions.Clear();
            yPostions.Clear();
        }
    }
}
