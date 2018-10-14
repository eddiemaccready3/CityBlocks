using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShuffleBlocks : MonoBehaviour {

    public GameObject[] blocks;
    private GameObject[] allGameObjectsArray;

    private int i;

    private Timer timer;
    
    public Button shuffleButton;

    private List<GameObject> blocksGameObjectsList = new List<GameObject>();
    private List<GameObject> spawnerGameObjectsList = new List<GameObject>();


	// Use this for initialization
	void Start()
    {
        Button btn = shuffleButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        timer = FindObjectOfType<Timer>();
    }

    void TaskOnClick()
    {
        ChangeBlockColor();
        timer.timeLeft = timer.timeLeft - 2f;

        blocksGameObjectsList.Clear();
        spawnerGameObjectsList.Clear();
    }

    private void ChangeBlockColor()
    {
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

        foreach (GameObject item in blocksGameObjectsList)
        {
            //print(item.name);
        }
        
        foreach (GameObject item in spawnerGameObjectsList)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in blocksGameObjectsList)
        {
            int i = Random.Range(0, blocks.Length);

            Instantiate(blocks[i],
            item.transform.position,
                Quaternion.identity);
            Destroy(item.gameObject);
        }

        foreach (GameObject item in spawnerGameObjectsList)
        {
            item.SetActive(true);
        }
    }
}
