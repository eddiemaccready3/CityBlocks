using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInOut : MonoBehaviour
{
    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private LayerMask layer;

    [SerializeField] private GameObject thisObject;
    
    private SpriteRenderer spriteRenderer;

    private RaycastHit2D hitShape;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonOut;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
        
            if(hitShape.collider != null && transform.gameObject == thisObject)
            {
                ButtonIn();
            }
        }
        else
        {
            ButtonOut();
        }
    }

    public void ButtonIn()
    {
        spriteRenderer.sprite = buttonIn;
    }

    public void ButtonOut()
    {
        spriteRenderer.sprite = buttonOut;
    }
}
