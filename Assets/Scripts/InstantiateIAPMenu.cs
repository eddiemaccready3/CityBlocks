using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateIAPMenu : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    [SerializeField] private GameObject thisObject;
    [SerializeField] private GameObject menuIAP;

    private GameObject[] menuObjects;

    [SerializeField] private Vector3 instantiatePos;

    private GameObject parentGameObject;
    private Transform parentTransform;
    [SerializeField] private string parentGameObjectName;

    [SerializeField] private string menuTag;

    [SerializeField] private int menuDepth;
    
    private RaycastHit2D hitShape;

    private void Start()
    {
        parentGameObject = GameObject.Find(parentGameObjectName);
        parentTransform = parentGameObject.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            menuObjects = GameObject.FindGameObjectsWithTag(menuTag);
            
            if (menuObjects.Length < menuDepth)
            {
                hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
        
                if(hitShape.collider != null && hitShape.transform.gameObject == thisObject)
                {
                    Instantiate(menuIAP, instantiatePos, Quaternion.identity, parentTransform);
                }
            }
        }
    }
}
