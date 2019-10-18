using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRising : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private float yMoveFactor = 0f;
    [SerializeField] private float acceleration = 1f;

    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;
    [SerializeField] private string menuObjectName;

    

    [SerializeField] private Vector3 hitShapePos;

    

    [SerializeField] private string menuName;
    private GameObject menuObject;

    [SerializeField] AudioClip sceneClip;
    [SerializeField] AudioClip menuClip;
    AudioSource audioSource;
    
    private bool move = false;

    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private ButtonActions buttonActionsScript;
    private PauseGameStatus pauseGameScript;
    private GlobalControl globalControlScript;
    private GameSaver gameSaverScript;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn; // set the sprite to sprite1
        }

        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        buttonActionsScript = FindObjectOfType<ButtonActions>();
        globalControlScript = FindObjectOfType<GlobalControl>();
        gameSaverScript = FindObjectOfType<GameSaver>();

        audioSource = GetComponent<AudioSource>();

        move = false;
    }

    private void FixedUpdate()
    {
        if (globalControlScript.deactivateMenu == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

                //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y + "; HitShape Pos: " + hitShapePos);

                if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                {
                    PlaySound(sceneClip);
                    ChangeSprite();
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                {
                    //GameObject.Find(menuName).gameObject.GetComponent<ButtonActions>().buttonAlreadyPressed = false;
                    ChangeSprite();
                    PlaySound(menuClip);
                    move = true;
                    UnpauseGame();
                }
            }

            if(move == true)
            {
                Move();
            }
        }
    }

    private void PlaySound(AudioClip sound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(sound);
        }
    }

    private void UnpauseGame()
    {
        pauseGameScript.pauseAuto = false;
        pauseGameScript.pauseManual = false;
    }

    private void Move()
    {
        menuObject = GameObject.Find(menuObjectName);
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
