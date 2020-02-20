using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShuffleBlocks : MonoBehaviour 
{
    [SerializeField] public int maxBlocksOnScreen;

    [SerializeField] LayerMask layerMask;

    private float shuffleLoopDelayIncrement = 0.08f;
    public float currentShuffleLoopDelay = 0f;

    private int shuffleCounter = 0;
    
    //private float rotationAngle;

    public GameObject[] blocks;
    private GameObject[] allGameObjectsArray;

    //private bool rotate = false;

    [SerializeField] private Timer timer;
    private SpinShuffleIcon spinShuffleIcon;
    private AutoShuffle autoShuffleScript;
    
    public List<GameObject> blocksGameObjectsList = new List<GameObject>();
    private List<GameObject> spawnerGameObjectsList = new List<GameObject>();

	// Use this for initialization
	void Start()
    {
        //timer = FindObjectOfType<Timer>();
        spinShuffleIcon = FindObjectOfType<SpinShuffleIcon>();
        autoShuffleScript = FindObjectOfType<AutoShuffle>();
        //rotationAngle = startRotationAngle;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            blocksGameObjectsList.Clear();
            spawnerGameObjectsList.Clear();

            allGameObjectsArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];

            for (int i = 0; i < allGameObjectsArray.Length; i++)
            {
                if (allGameObjectsArray[i].layer == 12)
                {
                    blocksGameObjectsList.Add(allGameObjectsArray[i]);
                }
            }
            RaycastHit2D hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layerMask);

            //print("Hitshape name: " + hitShape.transform.gameObject.name);
            if(hitShape.collider != null && blocksGameObjectsList.Count == maxBlocksOnScreen && transform.position == hitShape.transform.position)
            {
                InvokeChangeBlockColors();

                timer.timeLeft = timer.timeLeft - 2f;

                blocksGameObjectsList.Clear();
                spawnerGameObjectsList.Clear();
            }
        }

        //if(rotate)
        //{
        //    if(rotationAngle > (1))
        //    {
        //        this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        //        rotationAngle = rotationAngle * spinSpeed;
        //    }

        //    else
        //    {
        //        rotate = false;
        //        rotationAngle = startRotationAngle;
        //        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //    }
        //}
    }

    public void InvokeChangeBlockColors()
    {
        shuffleCounter = 0;
        Invoke("ChangeBlockColor", currentShuffleLoopDelay);
        currentShuffleLoopDelay += shuffleLoopDelayIncrement;
        Invoke("ChangeBlockColor", currentShuffleLoopDelay);
        currentShuffleLoopDelay += shuffleLoopDelayIncrement;
        Invoke("ChangeBlockColor", currentShuffleLoopDelay);
        currentShuffleLoopDelay += shuffleLoopDelayIncrement;
        Invoke("ChangeBlockColor", currentShuffleLoopDelay);
        currentShuffleLoopDelay += shuffleLoopDelayIncrement;
        Invoke("ChangeBlockColor", currentShuffleLoopDelay);
        currentShuffleLoopDelay = 0;
        //print("After, after shuffleCounter = " + shuffleCounter);
        //if(shuffleCounter == 5)
        //{
        //    print("shuffleCounter = 5");
        //    autoShuffleScript.tooFewBlocks = true;
        //    shuffleCounter = 0;
        //}
    }

    public void ChangeBlockColor()
    {
        blocksGameObjectsList.Clear();
        spawnerGameObjectsList.Clear();
        allGameObjectsArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        for (int i = 0; i < allGameObjectsArray.Length; i++)
        {
            if (allGameObjectsArray[i].layer == 12)
            {
                blocksGameObjectsList.Add(allGameObjectsArray[i]);
            }
            else if (allGameObjectsArray[i].layer == 8)
            {
                spawnerGameObjectsList.Add(allGameObjectsArray[i]);
            }
        }

        foreach (GameObject item in spawnerGameObjectsList)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in blocksGameObjectsList)
        {
            int i = Random.Range(0, blocks.Length);

            Destroy(item.gameObject);
            Instantiate(blocks[i],
            item.transform.position,
                Quaternion.identity);
        }

        foreach (GameObject item in spawnerGameObjectsList)
        {
            item.SetActive(true);
        }

        //print("Before shuffleCounter = " + shuffleCounter);
        shuffleCounter++;
        //print("After shuffleCounter = " + shuffleCounter);

        if(shuffleCounter == 5)
        {
            //print("shuffleCounter = 5");
            autoShuffleScript.tooFewBlocks = true;
            shuffleCounter = 0;
        }
    }
}
