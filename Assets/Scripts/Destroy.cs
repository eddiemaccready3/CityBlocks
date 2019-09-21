using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    [SerializeField] private int goldCoinValue;
    [SerializeField] private int silverCoinValue;
    [SerializeField] private int bronzeCoinValue;

    [SerializeField] private float delayBeforeFall = 0.05f;

    private Transform child;
    
    private float xPos;
    private float yPos;
    private float initialXPos;
    private float initialYPos;

    private string coinsBalanceName = "coins";

    private Counter counterScript;
    private CoinsMovement coinsMovementScript;

    public GameObject blockToBeDestroyed;
    GameObject blueExplosionParticle;
    GameObject greenExplosionParticle;
    GameObject redExplosionParticle;
    GameObject yellowExplosionParticle;
    GameObject pinkExplosionParticle;
    GameObject darkGreenExplosionParticle;
    GameObject darkPinkExplosionParticle;
    GameObject[] explosion;

    [SerializeField] private GameObject goldCoin;
    [SerializeField] private GameObject silverCoin;
    [SerializeField] private GameObject bronzeCoin;

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

        counterScript = FindObjectOfType<Counter>();
        coinsMovementScript = FindObjectOfType<CoinsMovement>();

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        blueExplosionParticle = Resources.Load("Particles/" + "ExplosionBlue") as GameObject;
        greenExplosionParticle = Resources.Load("Particles/" + "ExplosionGreen") as GameObject;
        redExplosionParticle = Resources.Load("Particles/" +  "ExplosionRed") as GameObject;
        yellowExplosionParticle = Resources.Load("Particles/" +  "ExplosionYellow") as GameObject;
        pinkExplosionParticle = Resources.Load("Particles/" +  "ExplosionPink") as GameObject;
        darkGreenExplosionParticle = Resources.Load("Particles/" +  "ExplosionDarkGreen") as GameObject;
        darkPinkExplosionParticle = Resources.Load("Particles/" +  "ExplosionDarkPink") as GameObject;
    }

    private void SetDestroyOn()
    {
        if (initialXPos == xPos)
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
        if (other.gameObject.transform.childCount > 0)
        {
            if(other.gameObject.transform.GetChild(0).tag == "Gold")
            {
                Instantiate(goldCoin, transform.position, Quaternion.identity);
                counterScript.AddInAmount(goldCoinValue, coinsBalanceName);
            }
        }

        tempMoveUp = new Vector2 (xPos, yPos + 1);
        tempMoveRight = new Vector2 (xPos + 10f, yPos);
        blockToBeDestroyed = other.gameObject;
        if (destroyOn && other.transform.gameObject.layer == 12)
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
                    else if (other.gameObject.name == "DarkGreenBlock(Clone)")
                    {
                        Instantiate(darkGreenExplosionParticle, transform.position, Quaternion.identity);
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
                    else if (other.gameObject.name == "DarkPinkBlock(Clone)")
                    {
                        Instantiate(darkPinkExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                    else if (other.gameObject.name == "PinkBlock(Clone)")
                    {
                        Instantiate(pinkExplosionParticle, transform.position, Quaternion.identity);
                        Invoke("DestroyParticle", 1f);
                    }
                }
                Invoke("MoveRight", delayBeforeFall);

                xPos = gameObject.transform.position.x;
                yPos = gameObject.transform.position.y;

                SetDestroyOn();
            }
        }
    }
}
