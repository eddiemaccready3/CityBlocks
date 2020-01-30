using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingObjects : MonoBehaviour {

    [SerializeField] private GameObject[] movingObjects;
    
    private float nextSpawn;
    [SerializeField] private float spawnRangeMin;
    [SerializeField] private float spawnRangeMax;
    
    // Use this for initialization
	void Start () {
        nextSpawn = Time.timeSinceLevelLoad + Random.Range(spawnRangeMin, spawnRangeMax);
		//SpawnObject();
	}
	
    


	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > nextSpawn)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        int i = Random.Range(0, movingObjects.Length - 1);
        Instantiate(movingObjects[i],
            transform.position,
            Quaternion.identity);

        nextSpawn = Time.timeSinceLevelLoad + Random.Range(spawnRangeMin, spawnRangeMax);
    }
}
