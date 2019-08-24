using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePathDots : MonoBehaviour
{
    [SerializeField] private GameObject trailDot;

    private float distanceBetweenDots;
    
    private Vector2 startingPos;
    private Vector2 currentPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(trailDot, startingPos, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = new Vector2(transform.position.x, transform.position.y);

        if(PythagoreanTheorem(FindDistance(currentPos.x, startingPos.x), FindDistance(currentPos.y, startingPos.y)) > 25f)
        {
            Instantiate(trailDot, currentPos, Quaternion.identity);
            startingPos = new Vector2(transform.position.x, transform.position.y);
        }
    }

    private float PythagoreanTheorem(float a, float b)
    {
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        return c;
    }

    private float FindDistance(float start, float end)
    {
        return Mathf.Abs(start - end);
    }
}
