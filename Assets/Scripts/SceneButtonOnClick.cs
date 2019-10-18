using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonOnClick : MonoBehaviour
{
    [SerializeField] AudioClip sceneClip;
    [SerializeField] private int sceneToLoad;

    [SerializeField] private Sprite buttonOut;
    [SerializeField] private Sprite buttonIn;

    AudioSource audioSource;

    private GameSaver gameSaverScript;

    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameSaverScript = FindObjectOfType<GameSaver>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = buttonOut;
        }
    }

    public void RunButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void PlaySFX()
    {
        PlaySound(sceneClip);
    }

    private void PlaySound(AudioClip sound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(sound);
        }
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
