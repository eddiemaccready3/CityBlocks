using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTAndC : MonoBehaviour
{
    [SerializeField] private string gameObjectName;

    [SerializeField] private LayerMask layer;
    
    private RaycastHit2D hitShape;

    [SerializeField] private int MinNoToDeactivateMenu;
    private int qtyMenusOnScreen;
    private GameObject[] menuObjects;
    [SerializeField] private string menuTagName;

    [SerializeField] AudioClip sceneClip;
    AudioSource audioSource;

    private GameSaver gameSaverScript;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        gameSaverScript = FindObjectOfType<GameSaver>();
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
                    PlaySound(sceneClip);
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if(qtyMenusOnScreen < MinNoToDeactivateMenu)
            {
                hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

                if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
                {
                    Application.OpenURL("https://gist.github.com/eddiemaccready3/8048af953ed079cb41c5af80c9ed9c39/");
                }
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
}
