using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum TeamEnum
{
    RED,
    BLUE
}

public static class Extentions
{
    public static Team GetTeam(this TeamEnum teamEnum)
    {
        return (teamEnum == TeamEnum.RED) ? PlayerManager.RedTeam : PlayerManager.BlueTeam;
    }
    public static Team GetOpposingTeam(this TeamEnum teamEnum)
    {
        return (teamEnum == TeamEnum.BLUE) ? PlayerManager.RedTeam : PlayerManager.BlueTeam;
    }
}


[System.Serializable]
public class Team
{
    public string Name;
    private int _Lives;
    public TextMeshProUGUI LivesTextComponent;

    public int Lives
    {
        get => _Lives;
        set {
            _Lives = value;
            UIManager.instance.UpdateLives(LivesTextComponent, value);
        }
    }
    
    public Team(string _name, int _lives, TextMeshProUGUI _livesTextComponent)
    {
        Name = _name;
        LivesTextComponent = _livesTextComponent;
        Lives = _lives;
    }
}
