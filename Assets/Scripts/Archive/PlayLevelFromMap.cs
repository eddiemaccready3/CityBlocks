using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevelFromMap : MonoBehaviour
{
    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    [SerializeField] private int sceneToLoad;

    [SerializeField] private Vector3 hitShapePos;

    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;

    private string sceneName;
    private string cityName;

    public bool mapSceneButtonActive = false;
    public bool changeSprite = false;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private GlobalControl globalControlScript;
    private Activate activeActivateScript;
    private LevelTextPopulater levelTextPopulater;

    private GameObject activeMarker;
 
    void Start ()
    {
        levelTextPopulater = FindObjectOfType<LevelTextPopulater>();
        
        cityName = levelTextPopulater.cityName.text;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonIn;
        }

        sceneName = SceneManager.GetActiveScene().name;

        globalControlScript = FindObjectOfType<GlobalControl>();
        //print("Marker name: " + cityName + "Marker");

        
        activeMarker = GameObject.Find(cityName + "Marker");
        activeActivateScript = activeMarker.GetComponent<Activate>();
    }
 
    void Update ()
    {
        if(globalControlScript.deactivateMenu == false)
        {
            if(mapSceneButtonActive == true)
            {
                //if (Input.GetMouseButton(0))
                //{
                    if(changeSprite == true)
                    {
                        ChangeSprite ();
                    }
                //}

                if (Input.GetMouseButtonUp(0))
                {
                    mapSceneButtonActive = false;
                    SceneManager.LoadScene(activeActivateScript.sceneToLoadGet);
                }

            }
        }
    }


    private void ChangeSprite ()
    {
        if (spriteRenderer.sprite == buttonOut)
        {
            spriteRenderer.sprite = buttonIn;
        }
        else
        {
             spriteRenderer.sprite = buttonOut;
        }

        changeSprite = false;
    }
}
