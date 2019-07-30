using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    [SerializeField] private Vector2 menuPos;
    [SerializeField] private Vector3 hitShapePos;

    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private PauseGame pauseGameScript;
    private GlobalControl globalControlScript;

    private GameObject pauseMenu;
    private GameObject optionsMenu;
 
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn; // set the sprite to sprite1
        }

        pauseGameScript = FindObjectOfType<PauseGame>();
        globalControlScript = FindObjectOfType<GlobalControl>();
    }
 
    void Update ()
    {
        if(globalControlScript.deactivateMenu == false)
        {
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if(pauseMenu == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

                    //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y + "; HitShape Pos: " + hitShapePos);

                    if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                    {
                        spriteRenderer.sprite = buttonIn;
                        //ChangeSprite ();
                        pauseGameScript.pauseAuto = true;
                        pauseGameScript.pauseManual = true;
                        Instantiate(menu, menuPos, Quaternion.identity);
                    }
                }
            }

            if (!Input.GetMouseButton(0))
            {
                //if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                //{
                    spriteRenderer.sprite = buttonOut;
                    //ChangeSprite ();
                //}
            }
                
                //if (Input.GetMouseButtonUp(0))
                //{
                //    if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                //    {
                //        ChangeSprite ();
                //    }
                //}
        }
    }

    private void ChangeSprite ()
    {
        if (transform.gameObject.name == hitShape.transform.gameObject.name && spriteRenderer.sprite == buttonOut)
        {
            spriteRenderer.sprite = buttonIn;
        }
        else
        {
            spriteRenderer.sprite = buttonOut;
        }
    }
}
