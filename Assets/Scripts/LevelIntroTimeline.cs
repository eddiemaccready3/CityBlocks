using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIntroTimeline : MonoBehaviour
{
    [SerializeField] private GameObject cityNameText;
    [SerializeField] private GameObject readySetGoText;
    [SerializeField] private GameObject readySetGo;
    [SerializeField] private GameObject timerText;
    [SerializeField] private GameObject blackBackground;
    
    [SerializeField] private float initialCityTextFadeInStart;
    [SerializeField] private float initialCityTextFadeOutStart;
    [SerializeField] private float initialCityTextFadeInDuration;
    [SerializeField] private float initialCityTextFadeOutDuration;

    [SerializeField] private float postCityTextFadeInStart;
    [SerializeField] private float postCityTextFadeOutStart;
    [SerializeField] private float postCityTextFadeInDuration;
    [SerializeField] private float postCityTextFadeOutDuration;

    [SerializeField] private float initialReadySetGoTextFadeInStart;
    [SerializeField] private float initialReadySetGoTextFadeInDuration;
    [SerializeField] private float initialReadySetGoStart;
    [SerializeField] private float initialReadySetGoDestroyStart;

    [SerializeField] private float postReadySetGoTextFadeInStart;
    [SerializeField] private float postReadySetGoTextFadeInDuration;
    [SerializeField] private float postReadySetGoStart;
    [SerializeField] private float postReadySetGoDestroyStart;

    [SerializeField] private float initialTimerTextFadeInStart;
    [SerializeField] private float initialTimerTextFadeInDuration;
    [SerializeField] private float initialTimerTextMoveStart;

    [SerializeField] private float postTimerTextFadeInStart;
    [SerializeField] private float postTimerTextFadeInDuration;
    [SerializeField] private float postTimerTextMoveStart;

    [SerializeField] private float initialBackgroundDestroyStart;
    [SerializeField] private float postBackgroundDestroyStart;
    
    private GameSaver gameSaverScript;

    Scene thisScene;
    private string sceneName;

    private void Awake()
    {
        thisScene = SceneManager.GetActiveScene();
        sceneName = thisScene.name;
        
        gameSaverScript = FindObjectOfType<GameSaver>();

        if (PlayerPrefs.GetInt(sceneName + gameSaverScript.keyLevelIntroCompleted) > 0)
        {
            //CityNameText timeline at first run
            cityNameText.GetComponent<FadeInText>().durationOfFadeIn = postCityTextFadeInDuration;
            cityNameText.GetComponent<FadeInText>().fadeStartTime = postCityTextFadeInStart;

            cityNameText.GetComponent<FadeOutText>().durationOfFadeOut = postCityTextFadeOutDuration;
            cityNameText.GetComponent<FadeOutText>().fadeStartTime = postCityTextFadeOutStart;

            //ReadySetGoText timeline at first run
            readySetGoText.GetComponent<FadeInText>().durationOfFadeIn = postReadySetGoTextFadeInDuration;
            readySetGoText.GetComponent<FadeInText>().fadeStartTime = postReadySetGoTextFadeInStart;

            readySetGo.GetComponent<ReadySetGo>().startTime = postReadySetGoStart;
            readySetGo.GetComponent<DestroySelf>().delay = postReadySetGoDestroyStart;

            //TimerText timeline at first run
            timerText.GetComponent<FadeInText>().durationOfFadeIn = postTimerTextFadeInDuration;
            timerText.GetComponent<FadeInText>().fadeStartTime = postTimerTextFadeInStart;
            timerText.GetComponent<TimerTextMovement>().moveDelay = postTimerTextMoveStart;

            //Black background destroy timeline at first run
            blackBackground.GetComponent<DestroySelf>().delay = postBackgroundDestroyStart;
        }

        else
        {
            //CityNameText timeline after first run
            cityNameText.GetComponent<FadeInText>().durationOfFadeIn = initialCityTextFadeInDuration;
            cityNameText.GetComponent<FadeInText>().fadeStartTime = initialCityTextFadeInStart;

            cityNameText.GetComponent<FadeOutText>().durationOfFadeOut = initialCityTextFadeOutDuration;
            cityNameText.GetComponent<FadeOutText>().fadeStartTime = initialCityTextFadeOutStart;

            //ReadySetGoText timeline after first run
            readySetGoText.GetComponent<FadeInText>().durationOfFadeIn = initialReadySetGoTextFadeInDuration;
            readySetGoText.GetComponent<FadeInText>().fadeStartTime = initialReadySetGoTextFadeInStart;

            readySetGo.GetComponent<ReadySetGo>().startTime = initialReadySetGoStart;
            readySetGo.GetComponent<DestroySelf>().delay = initialReadySetGoDestroyStart;

            //TimerText timeline after first run
            timerText.GetComponent<FadeInText>().durationOfFadeIn = initialTimerTextFadeInDuration;
            timerText.GetComponent<FadeInText>().fadeStartTime = initialTimerTextFadeInStart;
            timerText.GetComponent<TimerTextMovement>().moveDelay = initialTimerTextMoveStart;

            //Black background destroy timeline at first run
            blackBackground.GetComponent<DestroySelf>().delay = initialBackgroundDestroyStart;
        }
    }

    private void Start()
    {
       //print("keyNewShapeAnnounced: " + PlayerPrefs.GetInt(sceneName + gameSaverScript.keyNewShapeAnnounced));
    }
}
