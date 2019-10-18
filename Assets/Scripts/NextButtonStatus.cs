using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonStatus : MonoBehaviour
{
    private Scene scene;
    private string sceneName;

    [SerializeField] private Sprite active;
    [SerializeField] private Sprite inactive;

    private GameSaver gameSaverScript;

    private SpriteRenderer spriteRenderer; 
    
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        gameSaverScript = FindObjectOfType<GameSaver>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = inactive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(sceneName + gameSaverScript.keyPointsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(sceneName + gameSaverScript.keyCoinsStarEarnedPerLevel) > 0 || PlayerPrefs.GetInt(sceneName + gameSaverScript.keyMatchesStarEarnedPerLevel) > 0)
        {
            spriteRenderer.sprite = active;
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            spriteRenderer.sprite = inactive;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
