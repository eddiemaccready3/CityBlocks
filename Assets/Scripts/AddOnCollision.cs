using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOnCollision : MonoBehaviour
{
    [SerializeField] private Text shapeCountText;
    [SerializeField] private string gameObjectName;
    [SerializeField] private Sprite matched;
    [SerializeField] private Sprite unmatched;
    
    public int total = 0;

    private Transform counter;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
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
