using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] private int deactivateMenuCount;
    [SerializeField] private int sceneToLoad;

    [SerializeField] private string buttonType;
    [SerializeField] private string menuTagName;
    [SerializeField] private string menuObjectName;

    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private GameObject menu;

    [SerializeField] private Vector2 menuPos;

    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private float yMoveFactor = 0f;
    [SerializeField] private float acceleration = 1f;

    [SerializeField] AudioClip menuClip;
    [SerializeField] AudioClip sceneClip;
    [SerializeField] AudioClip exitClip;

    public bool buttonActive = true;
    private bool moveMenu = false;

    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private GameObject[] menuObjects;
    private GameObject menuObject;

    private SpriteRenderer spriteRenderer;

    private PauseGameStatus pauseGameStatusScript;
    private GameSaver gameSaverScript;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pauseGameStatusScript = FindObjectOfType<PauseGameStatus>();
        gameSaverScript = FindObjectOfType<GameSaver>();

        audioSource = GetComponent<AudioSource>();

        //pauseGameScript.pauseManual = false;
        //pauseGameScript.pauseAuto = false;
        SetPauseStatus();
        SetMenuStatus();
        
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonOut;
        }

        moveMenu = false;
    }

    private void Update()
    {
        SetPauseStatus();
        SetMenuStatus();
    }

    private void FixedUpdate()
    {
        if(moveMenu == true)
            {
                Move();
            }
    }

    private void SetMenuStatus()
    {
        menuObjects = GameObject.FindGameObjectsWithTag(menuTagName);

        if(menuObjects.Length > deactivateMenuCount)
        {
            buttonActive = false;
        }

        else
        {
            buttonActive = true;
        }
    }

    private void SetPauseStatus()
    {
        menuObjects = GameObject.FindGameObjectsWithTag(menuTagName);

        //foreach(GameObject go in menuObjects)
        //{
        //    print("menuObjects" + go.name);
        //}

        pauseGameStatusScript = FindObjectOfType<PauseGameStatus>();

        if (menuObjects.Length > 0)
        {
            pauseGameStatusScript.pauseManual = true;
            pauseGameStatusScript.pauseAuto = true;
            //print("Game paused.");
        }

        else
        {
            pauseGameStatusScript.pauseManual = false;
            pauseGameStatusScript.pauseAuto = false;
            //print("Game unpaused.");
        }
    }

    public void RunButton()
    {
        if(buttonActive == true)
        {
            if (buttonType == "Menu")
            {
                Instantiate(menu, menuPos, Quaternion.identity);
                PlaySound(menuClip);
            }

            else if (buttonType == "Scene")
            {
                //pauseGameScript.pauseManual = false;
                //pauseGameScript.pauseAuto = false;
                //print("Load scene, unpause.  Pause = " + pauseGameScript.pauseManual + ", " + pauseGameScript.pauseAuto);
                PlaySound(sceneClip);
                SceneManager.LoadScene(sceneToLoad);
            }

            else if (buttonType == "ExitRise")
            {
                PlaySound(exitClip);
                moveMenu = true;
                //print("Exit!");
            }

            else if (buttonType == "ExitDestroy")
            {
                PlaySound(exitClip);
                Destroy(menuObject);
            }
        }

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

    public void ButtonIn()
    {
        spriteRenderer.sprite = buttonIn;
    }

    public void ButtonOut()
    {
        spriteRenderer.sprite = buttonOut;
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