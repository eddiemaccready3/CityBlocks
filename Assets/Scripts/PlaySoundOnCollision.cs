using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    [SerializeField] AudioClip soundClip;
    [SerializeField] float audioVolume;
    AudioSource audioSource;

    private GameSaver gameSaverScript;

    [SerializeField] int layerToHit;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerToHit)
        {
            PlaySound(soundClip);
        }
    }

    private void PlaySound(AudioClip sound)
    {
        audioSource.volume = audioVolume;
        audioSource.PlayOneShot(sound);
    }
}
