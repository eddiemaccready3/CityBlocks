using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShuffleBlocks : MonoBehaviour {

    [SerializeField] float spinSpeed;
    [SerializeField] float startRotationAngle;
    [SerializeField] int maxBlocksOnScreen;
    
    private float rotationAngle;

    public GameObject[] blocks;
    private GameObject[] allGameObjectsArray;

    private int i;
    

    private bool rotate = false;

    private Timer timer;
    
    //public Button shuffleButton;

    private List<GameObject> blocksGameObjectsList = new List<GameObject>();
    private List<GameObject> spawnerGameObjectsList = new List<GameObject>();

    private RaycastHit2D hitShape;


	// Use this for initialization
	void Start()
    {
        //Button btn = shuffleButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        timer = FindObjectOfType<Timer>();
        rotationAngle = startRotationAngle;
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
            RaycastHit2D hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            foreach (GameObject item in blocksGameObjectsList)
            {
                //print(item);
            }
            if(hitShape != null && hitShape.collider != null && hitShape.transform.gameObject.layer == 13 && blocksGameObjectsList.Count == maxBlocksOnScreen && rotationAngle == startRotationAngle)
            {
                rotate = true;
                ChangeBlockColor();
                timer.timeLeft = timer.timeLeft - 2f;

                blocksGameObjectsList.Clear();
                spawnerGameObjectsList.Clear();
            }

            

        }
        if(rotate)
        {
            if(rotationAngle > (1))
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
                rotationAngle = rotationAngle * spinSpeed;
                //print("Rotation Angle: " + rotationAngle);
            }

            else
            {
                rotate = false;
                rotationAngle = startRotationAngle;
            }
        }
    }


    //void TaskOnClick()
    //{
    //    ChangeBlockColor();
    //    timer.timeLeft = timer.timeLeft - 2f;

    //    blocksGameObjectsList.Clear();
    //    spawnerGameObjectsList.Clear();
    //}

    private void ChangeBlockColor()
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
    }
}
