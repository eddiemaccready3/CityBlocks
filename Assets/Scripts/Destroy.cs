using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {

    //[SerializeField] AudioClip blockDestroy;

    private float xPos;
    private float yPos;
    private float initialXPos;
    private float initialYPos;
    [SerializeField] private float delayBeforeFall = 0.05f;

    public GameObject blockToBeDestroyed;
    GameObject blueExplosionParticle;
    GameObject greenExplosionParticle;
    GameObject purpleExplosionParticle;
    GameObject redExplosionParticle;
    GameObject yellowExplosionParticle;
    GameObject orangeExplosionParticle;
    GameObject pinkExplosionParticle;
    GameObject brownExplosionParticle;
    GameObject peachExplosionParticle;
    GameObject[] explosion;

    private Vector2 tempMoveUp;
    private Vector2 tempMoveRight;

    Scene m_Scene;

    private string sceneName;
    private string particlesName = "Particles";

    private bool destroyOn = true;

    AudioSource audioSource;

    private void Start()
    {
        initialXPos = gameObject.transform.position.x;
        initialYPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
        yPos = gameObject.transform.position.y;

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        blueExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionBlue") as GameObject;
        greenExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionGreen") as GameObject;
        purpleExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionPurple") as GameObject;
        redExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionRed") as GameObject;
        yellowExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionYellow") as GameObject;
        orangeExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionOrange") as GameObject;
        pinkExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionPink") as GameObject;
        brownExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionBrown") as GameObject;
        peachExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionPeach") as GameObject;
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
                    if (other.gameObject.name == sceneName + "BlueBlock(Clone)")
                    {
                        //print("Instatiate " + blueExplosionParticle);
                        Instantiate(blueExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "GreenBlock(Clone)")
                    {
                        Instantiate(greenExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "PurpleBlock(Clone)")
                    {
                        Instantiate(purpleExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "RedBlock(Clone)")
                    {
                        Instantiate(redExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "YellowBlock(Clone)")
                    {
                        Instantiate(yellowExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "OrangeBlock(Clone)")
                    {
                        Instantiate(orangeExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "PinkBlock(Clone)")
                    {
                        Instantiate(pinkExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "BrownBlock(Clone)")
                    {
                        Instantiate(brownExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == sceneName + "PeachBlock(Clone)")
                    {
                        Instantiate(peachExplosionParticle, transform.position, Quaternion.identity);
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
