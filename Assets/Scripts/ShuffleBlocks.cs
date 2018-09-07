using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShuffleBlocks : MonoBehaviour {

    public int qty;
    public GameObject[] blocks;

    private int i;
    
    public Button shuffleButton;
    private List<GameObject> blocksGameObjectsList = new List<GameObject>();
    private List<Vector3> blocksLocationList = new List<Vector3>();
    private List<Vector3> blocksNewLocationList = new List<Vector3>();
    private List<Vector3> tempBlocksLocationList = new List<Vector3>();
    private GameObject[] allGameObjectsArray;

	// Use this for initialization
	void Start()
    {
        Button btn = shuffleButton.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        allGameObjectsArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        //blocksGameObjectsList = new List<GameObject>();
        for (int i = 0; i < allGameObjectsArray.Length; i++)
        {
            if (allGameObjectsArray[i].layer == 12)
            {
                blocksGameObjectsList.Add(allGameObjectsArray[i]);
                blocksLocationList.Add(allGameObjectsArray[i].transform.position);
            }
        }

        tempBlocksLocationList = blocksLocationList;

        foreach (Vector3 item in tempBlocksLocationList)
        {
            print("Temp before: " + item.ToString());
        }

        while(tempBlocksLocationList.Count != 0) 
        {
	        int randNum = Random.Range(0, tempBlocksLocationList.Count);

            if (tempBlocksLocationList.Count == 1)
            {
                blocksNewLocationList.Add(tempBlocksLocationList[0]);
                blocksNewLocationList.Remove(tempBlocksLocationList[0]);
            }
            else
            {
                int tempRandNum = randNum;
                blocksNewLocationList.Add(tempBlocksLocationList[tempRandNum]);
                tempBlocksLocationList.Remove(tempBlocksLocationList[tempRandNum]);
            }
        }

        foreach (Vector3 item in blocksNewLocationList)
        {
            print("New randomized list: " + item.ToString());
        }

        foreach (Vector3 item in tempBlocksLocationList)
        {
            print("Temp after: " + item.ToString());
        }

        //{
        //    if (allGameObjectsArray[i].layer == 12)
        //    {
        //        blocksGameObjectsList.Add(allGameObjectsArray[i]);
        //        blocksLocationList.Add(allGameObjectsArray[i].transform.position);
        //    }
        //}

        


        //int i = Random.Range(0, blocks.Length);


        //Debug.Log("You have clicked the button!");
        //foreach (GameObject item in blocksGameObjectsList)
        //{
        //    print(item.ToString());
        //    Destroy(this.gameObject);
        //    foreach (Vector3 item in blocksLocationList)
        //    {
        //        int i = Random.Range(0, blocks.Length);

        //        // Spawn Block at current Position
        //        Instantiate(blocks[i],
        //                    new Vector3(blocksLocationList.x, blocksLocationList.y, blocksLocationList.z),
        //                    Quaternion.identity);
        //    }
        //}
    }
}
