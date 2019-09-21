using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovingShapeSprite : MonoBehaviour
{
    [SerializeField] private Sprite matched;
    [SerializeField] private Sprite unmatched;

    private SpriteRenderer spriteRenderer;

    private AddOnCollision scriptAddOnCollision;
    private UserInput scriptUserInput;

    private GameObject smallShapeToSet;
    private string smallShapeName;
    
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

        //smallShapeName = "Small" + transform.gameObject.name.Substring(0, transform.gameObject.name.Length-7);
        //smallShapeToSet = GameObject.Find(smallShapeName);

        //print("smallShapeName: " + smallShapeName);
        //print("smallShapeToSet.name: " + smallShapeToSet.name);

        //spriteRenderer = GetComponent<SpriteRenderer>();
        //if (spriteRenderer.sprite == null)
        //{
        //    spriteRenderer.sprite = unmatched;
        //}
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

        //    if(smallShapeToSet.GetComponent<AddOnCollision>().total > 0)
        //    {
        //        spriteRenderer.sprite = matched;
        //    }

        //    else
        //    {
        //        spriteRenderer.sprite = unmatched;
        //    }
    }
}
