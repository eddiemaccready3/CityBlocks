using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOnCollision : MonoBehaviour
{
    [SerializeField] private string gameObjectName;
    [SerializeField] private Sprite matched;
    [SerializeField] private Sprite unmatched;

    private string otherShapeName;
    
    public int total = 0;

    private Transform counter;

    private SpriteRenderer spriteRenderer;

    private Text shapeCountText;

    private void Start()
    {
        shapeCountText = GetComponentInChildren<Text>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = unmatched;
        }
        
        counter = transform.Find(gameObjectName);
        counter.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.gameObject.layer == 11)
        {
            otherShapeName = other.transform.gameObject.name;
            otherShapeName = otherShapeName.Replace("(Clone)", "");
            otherShapeName = otherShapeName.Remove(0,6);
            otherShapeName = "Small" + otherShapeName;
        }

        //print("otherShapeName: " + otherShapeName);
        //print("transform.gameObject.name: " + transform.gameObject.name);
                
        if(otherShapeName == transform.gameObject.name && other.transform.gameObject.layer == 11)
        {
            total += 1;
            shapeCountText.text = total.ToString();
        }

        if(total > 0)
        {
            counter.gameObject.SetActive(true);
            spriteRenderer.sprite = matched;
        }

        else
        {
            spriteRenderer.sprite = unmatched;
        }
    }
}
