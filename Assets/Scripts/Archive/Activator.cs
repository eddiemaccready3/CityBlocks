using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private RaycastHit2D hitShape;

    private GameObject[] allMarkers;
    private GameObject[] menuObjects;

    [SerializeField] private LayerMask layer;
    [SerializeField] private string sceneButtonTagName;
    [SerializeField] private string menuButtonTagName;
    [SerializeField] private string playButtonTagName;
    [SerializeField] private string mapMarkerTagName;
        
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hitShape.collider != null)
            {
                if(hitShape.transform.tag == sceneButtonTagName)
                {
                    hitShape.transform.gameObject.GetComponent<SceneButton>().sceneButtonActive = true;
                    hitShape.transform.gameObject.GetComponent<SceneButton>().changeSprite = true;
                }

                if(hitShape.transform.tag == mapMarkerTagName)
                {
                    allMarkers = GameObject.FindGameObjectsWithTag(mapMarkerTagName);

                    foreach(GameObject marker in allMarkers)
                    {
                        marker.transform.gameObject.GetComponent<Activate>().activeMarker = false;
                    }

                    hitShape.transform.gameObject.GetComponent<Activate>().activeMarker = true;
                }
            }

            else if(hitShape.collider == null)
            {
                    
                allMarkers = GameObject.FindGameObjectsWithTag(mapMarkerTagName);

                foreach(GameObject marker in allMarkers)
                {
                    marker.transform.gameObject.GetComponent<Activate>().activeMarker = false;
                }

                menuObjects = GameObject.FindGameObjectsWithTag("LevelMenu");
            
                for (var i = 0; i < menuObjects.Length; i++)
                {
                    Destroy(menuObjects[i]);
                }
            }
        }
    }
}
