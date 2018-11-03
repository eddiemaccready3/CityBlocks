using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressedAnim : MonoBehaviour {

	[SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;
    
 
    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;
 
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn; // set the sprite to sprite1
        }
    }
 
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            ChangeSprite ();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (hitShape.transform.gameObject.name == "PlayButton")
            {
                Invoke("LoadScene", 0.25f);
            }

            else
            {
                ChangeSprite ();
            }
        
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(3);
    }

    private void ChangeSprite ()
    {
        if (this.transform.gameObject.name == hitShape.transform.gameObject.name && this.spriteRenderer.sprite == buttonOut)
        {
            this.spriteRenderer.sprite = buttonIn;
        }
        else
        {
             this.spriteRenderer.sprite = buttonOut;
        }
    }
}
