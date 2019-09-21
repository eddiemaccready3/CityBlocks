using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSprite : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite toggledSprite;

    private bool toggled = false;

    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(toggled == true)
        {
            spriteRenderer.sprite = toggledSprite;
        }

        else
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
