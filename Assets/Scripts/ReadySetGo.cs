using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadySetGo : MonoBehaviour
{
    [SerializeField] private Text cityNameTextObject;

    [SerializeField] private string ready;
    [SerializeField] private string set;
    [SerializeField] private string go;

    [SerializeField] private float timeInterval;
    [SerializeField] public float startTime;

    private float timeOfInitialization;
    
    // Start is called before the first frame update
    void Start()
    {
        timeOfInitialization = Time.time;
        cityNameTextObject.text = ready;
    }

    private void Update()
    {
        if ((Time.time - timeOfInitialization) > (timeInterval + startTime))
        {
            cityNameTextObject.text = set;
        }

        if((Time.time - timeOfInitialization) > ((timeInterval * 2) + startTime))
        {
            cityNameTextObject.text = go;
        }
    }
}
