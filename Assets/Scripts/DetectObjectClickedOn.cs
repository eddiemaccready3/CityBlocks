using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectClickedOn : MonoBehaviour
{
    private RaycastHit2D hitMarker;

    

    [SerializeField] private LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hitMarker = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
        
        if (Input.GetMouseButtonDown(0))
        {
            //if(hitMarker.collider != null)
            //{
            //    print("Game Object clicked: " + hitMarker.transform.gameObject.name);
            //    hitMarker.transform.gameObject.GetComponent<CityInfo>().activeMarker = true;
            //}

            //else
            //{
            //    hitMarker.transform.gameObject.GetComponent<CityInfo>().activeMarker = false;
            //}
        }
    }
}
