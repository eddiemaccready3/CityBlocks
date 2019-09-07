using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapMenuRising : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private float yMoveFactor = 0f;
    [SerializeField] private float acceleration = 1f;

    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;
    [SerializeField] private string gameObjectTag;

    [SerializeField] private Vector3 hitShapePos;

    private GameObject menuObject;
    
    private bool move = false;

    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private PauseGameStatus pauseGameScript;
    private GlobalControl GlobalControlScript;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn; // set the sprite to sprite1
        }

        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        GlobalControlScript = FindObjectOfType<GlobalControl>();

        move = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y + "; HitShape Pos: " + hitShapePos);

            if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
            {
                ChangeSprite();
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
            {
                ChangeSprite();
                move = true;
                ReactivateMenu();
            }
        }

        if(move == true)
        {
            Move();
        }
    }

    private void ReactivateMenu()
    {
        GlobalControlScript.deactivateMenu = false;
    }

    private void Move()
    {
        menuObject = GameObject.FindGameObjectWithTag(gameObjectTag);
        xPosition = menuObject.transform.position.x;
        yPosition = menuObject.transform.position.y;
        moveDistance = acceleration * Time.deltaTime * speedModifier;
        yMovementEachFrame = yPosition - (moveDistance * yMoveFactor);

        menuObject.transform.position = new Vector2(xPosition, yMovementEachFrame);
        Invoke("DelayedDestroy", 0.75f);
    }

    private void DelayedDestroy()
    {
        
        Destroy(menuObject);
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
