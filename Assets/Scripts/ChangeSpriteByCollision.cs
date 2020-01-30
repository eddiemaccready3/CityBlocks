using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteByCollision : MonoBehaviour
{
    [SerializeField] private string otherTag;

    [SerializeField] private Sprite active;
    [SerializeField] private Sprite inactive;

    [SerializeField] LayerMask layerMask;

    private SpriteRenderer spriteRenderer;

    private Collider2D hitCollider;

    private Vector2 overlapBoxPosition;
    private Vector2 overlapBoxSize;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = inactive;
        }

        overlapBoxSize = new Vector2(0.01f, 0.01f);
    }

    private void Update()
    {
        overlapBoxPosition = new Vector2(transform.position.x, transform.position.y);
        hitCollider = Physics2D.OverlapBox(overlapBoxPosition, overlapBoxSize, layerMask);

        //print("hitCollider tag: " + hitCollider.tag);

        if(hitCollider != null && hitCollider.tag == otherTag)
        {
            spriteRenderer.sprite = active;
        }

        else
        {
            spriteRenderer.sprite = inactive;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    spriteRenderer.sprite = active;

    //    print ("otherTag: " + collision.tag);

    //    //if(other.tag == otherTag)
    //    //{
    //    //    spriteRenderer.sprite = active;
    //    //}

    //    //else
    //    //{
    //    //    spriteRenderer.sprite = inactive;
    //    //}
    //}
}
