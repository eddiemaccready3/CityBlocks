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

    [SerializeField] AudioClip sceneClip;
    [SerializeField] AudioClip menuClip;
    AudioSource audioSource;

    [SerializeField] private string menuTagName;
    [SerializeField] private string menuObjectName;

    [SerializeField] private int MinNoToDeactivateMenu;

    private GameObject[] menuObjects;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private PauseGameStatus pauseGameScript;
    private GlobalControl globalControlScript;
    private GameSaver gameSaverScript;

    private GameObject pauseMenu;
    private GameObject optionsMenu;
 
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn; // set the sprite to sprite1
        }

        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        globalControlScript = FindObjectOfType<GlobalControl>();
        gameSaverScript = FindObjectOfType<GameSaver>();
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
                    menuObjects = GameObject.FindGameObjectsWithTag(menuTagName);
                    
                    if(menuObjects != null && menuObjects.Length < MinNoToDeactivateMenu)
                    {
                        hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

                        //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y + "; HitShape Pos: " + hitShapePos);

                        if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                        {
                            spriteRenderer.sprite = buttonIn;
                            PlaySound(sceneClip);
                            //ChangeSprite ();
                            pauseGameScript.pauseAuto = true;
                            pauseGameScript.pauseManual = true;
                            Instantiate(menu, menuPos, Quaternion.identity);
                            //Invoke("PlaySoundAfterDelay()", 0.5f);
                        }
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
            //    hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
            //    if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
            //    {
            //        PlaySound(menuClip);
            //    }
            //}
                
                //if (Input.GetMouseButtonUp(0))
                //{
                //    if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
                //    {
                //        ChangeSprite ();
                //    }
                //}
        }
    }

    private void PlaySoundAfterDelay()
    {
        PlaySound(menuClip);
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

    private void PlaySound(AudioClip sound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(sound);
        }
    }
}
