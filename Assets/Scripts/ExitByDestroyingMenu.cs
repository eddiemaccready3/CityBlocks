using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitByDestroyingMenu : MonoBehaviour
{
    [SerializeField] private string menuTagName;
    [SerializeField] private string exitButtonName;
    
    private GameObject[] menuObjects;

    private RaycastHit2D hitShape;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hitShape.collider != null)
            {
                if(hitShape.transform.tag == exitButtonName)
                {
                    menuObjects = GameObject.FindGameObjectsWithTag(menuTagName);
            
                    for (var i = 0; i < menuObjects.Length; i++)
                    {
                        Destroy(menuObjects[i]);
                    }
                }
            }
        }
    }
}
