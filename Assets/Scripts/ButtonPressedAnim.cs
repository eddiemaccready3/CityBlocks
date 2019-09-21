using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressedAnim : MonoBehaviour {

	[SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    //[SerializeField] private int passedSceneToLoad;
    //[SerializeField] private int failedSceneToLoad;
    [SerializeField] private int sceneToLoad;
    //[SerializeField] private int passScore;
    //[SerializeField] private int passCoins;

    [SerializeField] private string gameObjectName;

    [SerializeField] private LayerMask layer;

    //public bool failed;

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
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
            {
                ChangeSprite ();
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
            {
                ChangeSprite ();
                SceneManager.LoadScene(sceneToLoad);
            }

            //GlobalControl.Instance.scoreBalanceSave = 0;
            //GlobalControl.Instance.coinsBalanceSave = 0;
            //GlobalControl.Instance.timeLeftSave = 124f;
        }
    }

    //private void LoadScene()
    //{
    //    SceneManager.LoadScene(passedSceneToLoad);
    //}

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
