using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    //[SerializeField] AudioClip blockDestroy;

    private float xPos;
    private float yPos;
    private float initialXPos;
    private float initialYPos;
    [SerializeField] private float delayBeforeFall = 0.05f;

    public GameObject blockToBeDestroyed;
    [SerializeField] GameObject blueExplosionParticle;
    [SerializeField] GameObject greenExplosionParticle;
    [SerializeField] GameObject purpleExplosionParticle;
    [SerializeField] GameObject redExplosionParticle;
    [SerializeField] GameObject yellowExplosionParticle;
    GameObject[] explosion;

    private Vector2 tempMoveUp;
    private Vector2 tempMoveRight;

    private string particlesName = "Particles";

    private bool destroyOn = true;

    AudioSource audioSource;

    private void Start()
    {
        initialXPos = gameObject.transform.position.x;
        initialYPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
        yPos = gameObject.transform.position.y;
        //audioSource = GetComponent<AudioSource>();
        //if (!audioSource.isPlaying)
        //{
        //    audioSource.PlayOneShot(blockDestroy);
        //}
    }

    private void SetDestroyOn()
    {
        if (initialYPos == yPos)
        {
            destroyOn = true;
        }
        else
        {
            destroyOn = false;
        }
    }

    private void MoveRight()
    {
        gameObject.transform.position = tempMoveRight;
        Invoke("DestroyGameObject", 1.1f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void DestroyParticle()
    {
        explosion = GameObject.FindGameObjectsWithTag (particlesName);
        for(int i = 0 ; i < explosion.Length; i ++)
        {
        Destroy(explosion[i]);
        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        

        tempMoveUp = new Vector2 (xPos, yPos + 1);
        tempMoveRight = new Vector2 (xPos + 10f, yPos);
        blockToBeDestroyed = other.gameObject;
        if (destroyOn)
        {    
            if (other)
            {
                if (destroyOn)
                {
                    Destroy(other.gameObject);
                    if (other.gameObject.name == "BlueBlock(Clone)")
                    {
                        Instantiate(blueExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == "GreenBlock(Clone)")
                    {
                        Instantiate(greenExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == "PurpleBlock(Clone)")
                    {
                        Instantiate(purpleExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == "RedBlock(Clone)")
                    {
                        Instantiate(redExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == "YellowBlock(Clone)")
                    {
                        Instantiate(yellowExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }

                }
                gameObject.transform.position = tempMoveUp;
                Invoke("MoveRight", delayBeforeFall);

                xPos = gameObject.transform.position.x;
                yPos = gameObject.transform.position.y;

                SetDestroyOn();
            }
        }
    }
}
