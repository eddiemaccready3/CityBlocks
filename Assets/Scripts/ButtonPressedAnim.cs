using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressedAnim : MonoBehaviour {

	[SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] AudioClip sceneClip;
    AudioSource audioSource;

    //[SerializeField] private int passedSceneToLoad;
    //[SerializeField] private int failedSceneToLoad;
    [SerializeField] private int sceneToLoad;
    
    [SerializeField] private int MinNoToDeactivateMenu;
    private int qtyMenusOnScreen;
    private GameObject[] menuObjects;
    [SerializeField] private string menuTagName;
    //[SerializeField] private int passScore;
    //[SerializeField] private int passCoins;

    [SerializeField] private string gameObjectName;

    [SerializeField] private LayerMask layer;

    private GameSaver gameSaverScript;

    //public bool failed;

    private SpriteRenderer spriteRenderer;

    private RaycastHit2D hitShape;
 
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        gameSaverScript = FindObjectOfType<GameSaver>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn; // set the sprite to sprite1
        }
    }
 
    void Update ()
    {
        menuObjects = GameObject.FindGameObjectsWithTag(menuTagName);

        if(menuObjects == null)
        {
            qtyMenusOnScreen = 0;
        }
        else
        {
            qtyMenusOnScreen = menuObjects.Length;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(qtyMenusOnScreen < MinNoToDeactivateMenu)
            {
                hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

                if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
                {
                    ChangeSprite ();
                    PlaySound(sceneClip);
                }
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if(qtyMenusOnScreen < MinNoToDeactivateMenu)
            {
                hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

                if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
                {
                    ChangeSprite ();
                    SceneManager.LoadScene(sceneToLoad);
                }
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

    private void PlaySound(AudioClip sound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(sound);
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
