using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSprite : MonoBehaviour
{
    [SerializeField] private string spriteGOName;
    
    private SpriteRenderer thisSpriteRenderer;
    private SpriteRenderer sourceSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        sourceSpriteRenderer = GameObject.Find(spriteGOName).GetComponent<SpriteRenderer>();
        
        thisSpriteRenderer = GetComponent<SpriteRenderer>();

        thisSpriteRenderer.sprite = sourceSpriteRenderer.sprite;
    }
}
