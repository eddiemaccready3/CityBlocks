using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    // Start is called before the first frame update
    private int sceneToLoad;

    private int sceneNo;

    [SerializeField] private Vector3 hitShapePos;

    [SerializeField] private LayerMask layer;

    [SerializeField] private string gameObjectName;

    private SpriteRenderer spriteRenderer; 

    private RaycastHit2D hitShape;

    private GlobalControl globalControlScript;
 
    void Start ()
    {
        sceneNo = SceneManager.GetActiveScene().buildIndex;
    }
 
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            //print(hitShape.transform.gameObject.name + " Position: " + hitShape.transform.position.x + ", " + hitShape.transform.position.y + "; HitShape Pos: " + hitShapePos);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            hitShape = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, layer);

            if(hitShape.collider != null && hitShape.transform.gameObject.name == gameObjectName && hitShape.transform.position == hitShapePos)
            {
                Invoke("LoadScene", 0.75f);
            }
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneNo);
    }
}
