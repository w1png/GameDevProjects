using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int startCoins = 500;
    private static int _Coins;

    public static int coins
    {
        get => _Coins;
        set
        {
            _Coins = value;
            UIManager.instance.coins = value;
        }
    }

    public int startLives = 10;
    private static int _Lives;
    public static int lives
    {
        get => _Lives;
        set
        {
            _Lives = value;
            UIManager.instance.lives = value;

            if (lives <= 0)
                EndGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        coins = startCoins;
        lives = startLives;

        UIManager.instance.SetScene(UIManager.Scene.GAME);
    }

    public static void EndGame()
    {
        Time.timeScale = 0;
        UIManager.instance.SetScene(UIManager.Scene.MAIN_MENU);
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.instance.SetScene(UIManager.Scene.PAUSE);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void Start()
    {
        coins = startCoins;
        lives = startLives;
    }
 }
