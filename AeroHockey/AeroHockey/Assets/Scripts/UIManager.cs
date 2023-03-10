using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one ui manager on the scene");
            return;
        }
        instance = this;
    }


    //[Header("Text GUI")]
    [SerializeField]
    public TextMeshProUGUI blueLivesComponent;
    [SerializeField]
    public TextMeshProUGUI redLivesComponent;

    private string FormatLives(int lives)
    {
        return "Lives: " + lives.ToString();
    }

    public void UpdateLives(TextMeshProUGUI livesComponent, int lives)
    {
        livesComponent.text = FormatLives(lives);
    }

    public void SetGameOver(TeamEnum team)
    {
        Debug.Log(team.ToString());
    }



}
