using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int startLives;
    public static Team BlueTeam;
    public static Team RedTeam;

    void Awake()
    {
        BlueTeam = new Team("Blue", startLives, UIManager.instance.blueLivesComponent);
        Debug.Log(BlueTeam.Name);
        RedTeam = new Team("Red", startLives, UIManager.instance.redLivesComponent);
    }

    private void Update()
    {
        if (BlueTeam.Lives == 0)
        {
            UIManager.instance.SetGameOver(TeamEnum.RED);
            return;
        }
        else if (RedTeam.Lives == 0)
        {
            UIManager.instance.SetGameOver(TeamEnum.BLUE);
        }
    }

    public static void TeamScored(TeamEnum scoringTeam)
    {
        Team team = scoringTeam.GetTeam();
        Debug.Log(team.Name + " scored!");
    }
}
