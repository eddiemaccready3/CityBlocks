using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneActivator : MonoBehaviour
{
    private RaycastHit2D hitShape;

    [SerializeField] private string sceneButtonTagName;
        
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
            }
        }
    }
}
