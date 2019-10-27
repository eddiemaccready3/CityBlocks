using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class PlanePathDots : MonoBehaviour
{
    [SerializeField] private GameObject trailDot;
    private GameObject dotsParentTran;

    private float distanceBetweenDots;
    
    private Vector3 startingPos;
    private Vector3 currentPos;

    
    
    // Start is called before the first frame update
    void Start()
    {
        dotsParentTran = GameObject.Find("PlaneTrail");
        
        startingPos = new Vector3(transform.position.x, transform.position.y, 0f);
        Instantiate(trailDot, startingPos, Quaternion.identity, dotsParentTran.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = new Vector3(transform.position.x, transform.position.y, 0f);

        if(TrigFunctions.PythagoreanTheorem(TrigFunctions.FindDistance(currentPos.x, startingPos.x), TrigFunctions.FindDistance(currentPos.y, startingPos.y)) > 25f)
        {
            Instantiate(trailDot, currentPos, Quaternion.identity, dotsParentTran.transform);
            startingPos = new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }
}
