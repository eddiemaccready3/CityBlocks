using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private float sliderStartPosX;
    [SerializeField] private float sliderEndPosX;
    
    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;

    private float musicSliderSetPosX;
    private float sfxSliderSetPosX;

    private float convertVolumeScale;
    private float musicSliderVolume;
    private float sfxSliderVolume;

    private Vector2 mousePos;

    private RaycastHit2D hitShape;

    private GameSaver gameSaverScript;

    private AudioSource musicAudioSource;

    private float nothing;
    private bool noBool;
 
    void Start ()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
        convertVolumeScale = 1 / (sliderEndPosX - sliderStartPosX);
        musicSliderSetPosX = sliderStartPosX + (PlayerPrefs.GetFloat(gameSaverScript.musicVolumeLevel) / (1 / (sliderEndPosX - sliderStartPosX)));
        sfxSliderSetPosX = sliderStartPosX + (PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel) / (1 / (sliderEndPosX - sliderStartPosX)));
        musicAudioSource = Camera.main.GetComponentInChildren<AudioSource>();

        if (transform.gameObject.name == "musicSlider")
        {
            transform.position = new Vector2(musicSliderSetPosX, transform.position.y);
        }

        if (transform.gameObject.name == "sfxSlider")
        {
            transform.position = new Vector2(sfxSliderSetPosX, transform.position.y);
        }
    }
 
    void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y);

            if (hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName)
            {
                transform.position = new Vector2(Mathf.Clamp(mousePos.x, sliderStartPosX, sliderEndPosX), transform.position.y);
            }

            AdjustVolume();
        }
    }

    private void AdjustVolume()
    {
        if (transform.gameObject.name == "musicSlider")
        {
            musicSliderVolume = (transform.position.x - sliderStartPosX) * convertVolumeScale;
            PlayerPrefs.SetFloat(gameSaverScript.musicVolumeLevel, musicSliderVolume);
            //gameSaverScript.musicVolume = musicSliderVolume;
            musicAudioSource.volume = musicSliderVolume;
        }

        if (transform.gameObject.name == "sfxSlider")
        {
            sfxSliderVolume = (transform.position.x - sliderStartPosX) * convertVolumeScale;
            PlayerPrefs.SetFloat(gameSaverScript.sfxVolumeLevel, sfxSliderVolume);
            gameSaverScript.sfxVolume = sfxSliderVolume;
        }
    }
}
