using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1 build manager on the scene.");
            return;
        }

        instance = this;
    }

    [Header("\"Scenes\"")]
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public enum Scene
    {
        MAIN_MENU,
        GAME,
        PAUSE,
    }

    public void SetScene(Scene scene)
    {
        switch (scene)
        {
            case Scene.GAME:
                MainMenu.SetActive(false);
                PauseMenu.SetActive(false);
                break;
            case Scene.MAIN_MENU:
                MainMenu.SetActive(true);
                break;
            case Scene.PAUSE:
                PauseMenu.SetActive(true);
                break;
        }
    }

    [Header("UI text")]
    private TextMeshProUGUI errorTextComponent;
    public string errorText
    {
        set
        {
            StartCoroutine(DrawError(value));
        }
    }

    public TextMeshProUGUI waveTimerCoundown;
    public float waveCountdown
    {
        set => waveTimerCoundown.text = "Time to next wave: " + string.Format("{0:00.00}", Mathf.Clamp(value, 0f, Mathf.Infinity));
    }

    public TextMeshProUGUI waveCounterComponent;
    public int waveCounter
    {
        set => waveCounterComponent.text = "Wave: " + value.ToString();
    }

    public TextMeshProUGUI coinsComponent;
    public int coins
    {
        set => coinsComponent.text = "Coins: " + value.ToString();
    }

    public TextMeshProUGUI livesComponent;
    public int lives
    {
        set => livesComponent.text = "Lives: " + value.ToString();
    }


    private void Start()
    {
        errorTextComponent = GameObject.Find("ErrorText").GetComponent<TextMeshProUGUI>();
        errorTextComponent.CrossFadeAlpha(0f, 0f, true);

    }

    private IEnumerator DrawError(string error)
    {
        errorTextComponent.text = error;
        errorTextComponent.CrossFadeAlpha(1f, 0.3f, true);
        yield return new WaitForSeconds(0.6f);
        errorTextComponent.CrossFadeAlpha(0f, 0.3f, true);
    }

}
