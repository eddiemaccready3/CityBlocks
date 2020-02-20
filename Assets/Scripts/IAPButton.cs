using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButton : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject thisObject;
    [SerializeField] private string gameObjectName;
    [SerializeField] private GameObject menuObject;

    [SerializeField] private string markerToSpinName;
 
    [SerializeField] private GameObject[] deactivateObjects;
    [SerializeField] private GameObject[] activateObjects;

    [SerializeField] string gameObjectToDestroyName;
    [SerializeField] string gameObjectToFindToDeactivate;
    [SerializeField] string gameObjectToFindToActivate;
    [SerializeField] string thisCityName;
    
    private RaycastHit2D hitShape;

    private GameSaver gameSaverScript;

    private void Start()
    {
        gameSaverScript = FindObjectOfType<GameSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);
        
            if(hitShape.collider != null && hitShape.transform.gameObject == thisObject)
            {
                //IAPManager.Instance.BuyFullGame();

                PlayerPrefs.SetInt(thisCityName + gameSaverScript.keyPointsStarEarnedPerLevel, 1);
                PlayerPrefs.SetInt(gameSaverScript.keySetBangkokMarkerToActive, 1);

                //GameObject.Find(markerToSpinName).GetComponent<SpinObject>().rotateMarker = true;

                Destroy(GameObject.Find(gameObjectToDestroyName));

                GameObject.Find(gameObjectToFindToDeactivate).GetComponent<Collider2D>().enabled = false;
                GameObject.Find(gameObjectToFindToActivate).GetComponent<Collider2D>().enabled = true;
                
                foreach(GameObject g in activateObjects)
                {
                    g.SetActive(true);
                }
                
                foreach(GameObject g in deactivateObjects)
                {
                    g.SetActive(false);
                }
            }
        }
    }
}
