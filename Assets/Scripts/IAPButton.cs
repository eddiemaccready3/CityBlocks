using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButton : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject thisObject;
    
    private RaycastHit2D hitShape;

    private GameSaver gameSaverScript;

    private void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
        
            if(hitShape.collider != null && hitShape.transform.gameObject == thisObject)
            {
                IAPManager.Instance.BuyFullGame();
            }
        }
    }
}
