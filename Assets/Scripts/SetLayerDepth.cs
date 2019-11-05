using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLayerDepth : MonoBehaviour
{
    [SerializeField] private int setSortingOrder;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Canvas>().sortingOrder = setSortingOrder;
    }
}
