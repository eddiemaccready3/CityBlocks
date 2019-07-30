using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {

    //[SerializeField] AudioClip blockDestroy;

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
    //GameObject purpleExplosionParticle;
    GameObject redExplosionParticle;
    GameObject yellowExplosionParticle;
    //GameObject orangeExplosionParticle;
    GameObject pinkExplosionParticle;
    //GameObject brownExplosionParticle;
    //GameObject peachExplosionParticle;
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

        //blueExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionBlue") as GameObject;
        //greenExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionGreen") as GameObject;
        //purpleExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionPurple") as GameObject;
        //redExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionRed") as GameObject;
        //yellowExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionYellow") as GameObject;
        //orangeExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionOrange") as GameObject;
        //pinkExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionPink") as GameObject;
        //brownExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionBrown") as GameObject;
        //peachExplosionParticle = Resources.Load("Particles/" + sceneName + "ExplosionPeach") as GameObject;

        blueExplosionParticle = Resources.Load("Particles/" + "ExplosionBlue") as GameObject;
        greenExplosionParticle = Resources.Load("Particles/" + "ExplosionGreen") as GameObject;
        redExplosionParticle = Resources.Load("Particles/" +  "ExplosionRed") as GameObject;
        yellowExplosionParticle = Resources.Load("Particles/" +  "ExplosionYellow") as GameObject;
        pinkExplosionParticle = Resources.Load("Particles/" +  "ExplosionPink") as GameObject;
        darkGreenExplosionParticle = Resources.Load("Particles/" +  "ExplosionDarkGreen") as GameObject;
        darkPinkExplosionParticle = Resources.Load("Particles/" +  "ExplosionDarkPink") as GameObject;
        //audioSource = GetComponent<AudioSource>();
        //if (!audioSource.isPlaying)
        //{
        //    audioSource.PlayOneShot(blockDestroy);
        //}
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
                //print("Block " + other.gameObject.name + "has coin named" + other.gameObject.transform.GetChild(0).name + "!");
            }

            //else if(other.gameObject.transform.GetChild(0).tag == "Silver")
            //{
            //    Instantiate(silverCoin, transform.position, Quaternion.identity);
            //    counterScript.AddInAmount(silverCoinValue, coinsBalanceName);
            //    print("Block " + other.gameObject.name + "has coin named" + other.gameObject.transform.GetChild(0).name + "!");
            //}

            //else if(other.gameObject.transform.GetChild(0).tag == "Bronze")
            //{
            //    Instantiate(bronzeCoin, transform.position, Quaternion.identity);
            //    counterScript.AddInAmount(bronzeCoinValue, coinsBalanceName);
            //    print("Block " + other.gameObject.name + "has coin named" + other.gameObject.transform.GetChild(0).name + "!");
            //}
        }
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
                    
                    //if (other.transform.childCount > 0)
                    //{
                    //    //print("Child coin tag: " + other.transform.GetChild.tag);
                    //    //if (child.tag == "Gold")
                    //    //{
                    //    //    coinsCounterScript.startCoinCounter = true;
                    //    //    coinsCounterScript.totalCoinBalance += 25;
                    //    //}
                    //}

                    if (other.gameObject.name == "BlueBlock(Clone)")
                    {
                        //print("Instatiate " + blueExplosionParticle);
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

                    //if (other.gameObject.name == sceneName + "BlueBlock(Clone)")
                    //{
                    //    //print("Instatiate " + blueExplosionParticle);
                    //    Instantiate(blueExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "GreenBlock(Clone)")
                    //{
                    //    Instantiate(greenExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "PurpleBlock(Clone)")
                    //{
                    //    Instantiate(purpleExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "RedBlock(Clone)")
                    //{
                    //    Instantiate(redExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "YellowBlock(Clone)")
                    //{
                    //    Instantiate(yellowExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "OrangeBlock(Clone)")
                    //{
                    //    Instantiate(orangeExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "PinkBlock(Clone)")
                    //{
                    //    Instantiate(pinkExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "BrownBlock(Clone)")
                    //{
                    //    Instantiate(brownExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}
                    //else if (other.gameObject.name == sceneName + "PeachBlock(Clone)")
                    //{
                    //    Instantiate(peachExplosionParticle, transform.position, Quaternion.identity);
                    //    Invoke("DestroyParticle", 1f);
                    //}

                }
                //gameObject.transform.position = tempMoveUp;
                Invoke("MoveRight", delayBeforeFall);

                xPos = gameObject.transform.position.x;
                yPos = gameObject.transform.position.y;

                SetDestroyOn();
            }
        }
    }
}
