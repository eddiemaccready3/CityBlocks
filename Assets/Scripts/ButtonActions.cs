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

    private bool buttonActive = true;
    private bool moveMenu = false;

    private float xMovementEachFrame;
    private float yMovementEachFrame;
    private float moveDistance;
    private float xPosition;
    private float yPosition;

    private GameObject[] menuObjects;
    private GameObject menuObject;

    private SpriteRenderer spriteRenderer;

    private PauseGameStatus pauseGameScript;

    // Start is called before the first frame update
    void Start()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();

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
        //Array.Clear(menuObjects, 0, menuObjects.Length);

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

        pauseGameScript = FindObjectOfType<PauseGameStatus>();

        if (menuObjects.Length > 0)
        {
            pauseGameScript.pauseManual = true;
            pauseGameScript.pauseAuto = true;
            //print("Game paused.");
        }

        else
        {
            pauseGameScript.pauseManual = false;
            pauseGameScript.pauseAuto = false;
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
            }

            else if (buttonType == "Scene")
            {
                //pauseGameScript.pauseManual = false;
                //pauseGameScript.pauseAuto = false;
                //print("Load scene, unpause.  Pause = " + pauseGameScript.pauseManual + ", " + pauseGameScript.pauseAuto);
                SceneManager.LoadScene(sceneToLoad);
            }

            else if (buttonType == "ExitRise")
            {
                moveMenu = true;
                //print("Exit!");
            }

            else if (buttonType == "ExitDestroy")
            {
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
}