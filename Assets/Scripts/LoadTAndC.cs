using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTAndC : MonoBehaviour
{
    [SerializeField] private string gameObjectName;

    [SerializeField] private LayerMask layer;
    
    private RaycastHit2D hitShape;

    void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
            {
                Application.OpenURL("https://gist.github.com/eddiemaccready3/8048af953ed079cb41c5af80c9ed9c39/");
            }
        }
    }
}
