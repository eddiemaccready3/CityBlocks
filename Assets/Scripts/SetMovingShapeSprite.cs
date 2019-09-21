using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovingShapeSprite : MonoBehaviour
{
    [SerializeField] private Sprite matched;
    [SerializeField] private Sprite unmatched;

    private SpriteRenderer spriteRenderer;

    private UserInput scriptUserInput;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = unmatched;
        }

        else
        {
            spriteRenderer.sprite = unmatched;
        }

        scriptUserInput = FindObjectOfType<UserInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptUserInput.shapesMatched.Contains(transform.gameObject.name.Substring(0, transform.gameObject.name.Length - 7)))
        {
            spriteRenderer.sprite = matched;
        }

        else
        {
            spriteRenderer.sprite = unmatched;
        }
    }
}
