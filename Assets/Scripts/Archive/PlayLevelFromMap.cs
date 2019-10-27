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

    [SerializeField] AudioClip sceneClip;
    AudioSource audioSource;
    private bool soundPlayed;

    private string sceneName;
    private string cityName;

    public bool mapSceneButtonActive = false;
    public bool changeSprite = false;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private GlobalControl globalControlScript;
    private Activate activeActivateScript;
    private LevelTextPopulater levelTextPopulater;
    private GameSaver gameSaverScript;

    private GameObject activeMarker;

 
    void Start ()
    {
        levelTextPopulater = FindObjectOfType<LevelTextPopulater>();
        
        cityName = levelTextPopulater.cityName.text;
        cityName = cityName.Replace(" ", "");
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

        audioSource = GetComponent<AudioSource>();
        soundPlayed = false;

        gameSaverScript = FindObjectOfType<GameSaver>();
    }
 
    void Update ()
    {
        if(globalControlScript.deactivateMenu == false)
        {
            if(mapSceneButtonActive == true)
            {
                spriteRenderer.sprite = buttonIn;
                
                if(soundPlayed == false)
                {
                    PlaySound(sceneClip);
                    soundPlayed = true;
                }
                
                //if (Input.GetMouseButton(0))
                //{
                    //if(changeSprite == true)
                    //{
                        //ChangeSprite ();
                    //}
                //}

                if (Input.GetMouseButtonUp(0))
                {
                    mapSceneButtonActive = false;
                    SceneManager.LoadScene(activeActivateScript.sceneToLoadGet);
                }

            }
        }

        if(!Input.GetMouseButton(0))
        {
            spriteRenderer.sprite = buttonOut;
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

    private void PlaySound(AudioClip sound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(sound);
        }
    }
}
