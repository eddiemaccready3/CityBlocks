using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] blocks;

    private float nextSpawn;

    private void Start()
    {
        nextSpawn = nextSpawn + Random.Range (0f, 3f);
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawn)
        {
            nextSpawn = Time.timeSinceLevelLoad + Random.Range (0.5f, 3f);
            int i = Random.Range(0, blocks.Length);
            Instantiate(blocks[i],
                transform.position,
                Quaternion.identity);
        }
        
        //timeElapsed = timeNow;
        //int i = Random.Range(0, blocks.Length);
        //randSeconds = Random.Range(5, 15f);
        //if (
        //StartCoroutine(SpawnBlocks(i));
    }


    //IEnumerator SpawnBlocks(int i)
    //{
    //    yield return new WaitForSeconds(timeElapsed);
    //    Instantiate(blocks[i],
    //        transform.position,
    //        Quaternion.identity);
    //}
}
