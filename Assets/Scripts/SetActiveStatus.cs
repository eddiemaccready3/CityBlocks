using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveStatus : MonoBehaviour
{
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;
    
    [SerializeField] private int minRequired;

    [SerializeField] private Text minReqText;

    private int textConvertedToInt;

    private bool changeSprite;

    private SpriteRenderer spriteRenderer;

    private LevelPassReqs levelPassReqsScript;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = inactiveSprite;
        }

        changeSprite = false;

        textConvertedToInt = int.Parse(minReqText.text);

        levelPassReqsScript = FindObjectOfType<LevelPassReqs>();
    }

    void Update()
    {
        textConvertedToInt = int.Parse(minReqText.text);
        if(changeSprite == false)
        {
            if(gameObject.name == "PointsStar")
            {
                if(textConvertedToInt >= levelPassReqsScript.passPoints)
                {
                    spriteRenderer.sprite = activeSprite;
                    changeSprite = true;
                    transform.localScale += new Vector3(0.1F, 0.1f, 0);
                    Invoke("ReduceSize", 0.25f);
                }
                else
                {
                     spriteRenderer.sprite = inactiveSprite;
                }
            }

            else if(gameObject.name == "CoinsStar")
            {
                if(textConvertedToInt >= levelPassReqsScript.passCoins)
                {
                    spriteRenderer.sprite = activeSprite;
                    changeSprite = true;
                    transform.localScale += new Vector3(0.1F, 0.1f, 0);
                    Invoke("ReduceSize", 0.25f);
                }
                else
                {
                     spriteRenderer.sprite = inactiveSprite;
                }
            }

            else if(gameObject.name == "MatchesStar")
            {
                if(textConvertedToInt >= levelPassReqsScript.passMatches)
                {
                    spriteRenderer.sprite = activeSprite;
                    changeSprite = true;
                    transform.localScale += new Vector3(0.1F, 0.1f, 0);
                    Invoke("ReduceSize", 0.25f);
                }
                else
                {
                     spriteRenderer.sprite = inactiveSprite;
                }
            }
        }
    }

    private void ReduceSize()
    {
        transform.localScale -= new Vector3(0.1F, 0.1f, 0);
    }
}
