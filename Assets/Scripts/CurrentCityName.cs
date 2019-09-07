using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCityName : MonoBehaviour
{
    [SerializeField] private Text cityNameTextObject;
    [SerializeField] private string cityName;
    
    // Start is called before the first frame update
    void Start()
    {
        cityNameTextObject.text = cityName;
    }
}
