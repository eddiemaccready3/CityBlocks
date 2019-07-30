using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneActivator : MonoBehaviour
{
    private RaycastHit2D hitShape;

    [SerializeField] private string mapSceneButtonTagName;
        
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
                if(hitShape.transform.tag == mapSceneButtonTagName)
                {
                    hitShape.transform.gameObject.GetComponent<PlayLevelFromMap>().mapSceneButtonActive = true;
                    hitShape.transform.gameObject.GetComponent<PlayLevelFromMap>().changeSprite = true;
                }
            }
        }
    }
}
