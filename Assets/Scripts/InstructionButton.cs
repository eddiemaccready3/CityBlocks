using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionButton : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    [SerializeField] GameObject instructionsNextButton;

    [SerializeField] private string thisObjectName;
    
    private RaycastHit2D hitShape;

    [SerializeField] AudioClip sceneClip;
    AudioSource audioSource;

    private GameSaver gameSaverScript;

    [SerializeField] private GameObject [] gameObjectsToActivate;
    [SerializeField] private GameObject [] gameObjectsToDeactivate;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layer);

            //print("hitShape.transform.gameObject" + hitShape.transform.gameObject);

            if(hitShape.collider != null && hitShape.transform.gameObject.name == thisObjectName)
            {
                PlaySound(sceneClip);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(hitShape.collider != null && hitShape.transform.gameObject.name == thisObjectName)
            {
                //Gameobjects
                foreach(GameObject g in gameObjectsToDeactivate)
                {
                    g.SetActive(false);
                }
                foreach(GameObject g in gameObjectsToActivate)
                {
                    g.SetActive(true);
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
