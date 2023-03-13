using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Game settings")]
    [SerializeField]
    public int startLives;

    public static Team BlueTeam;
    public static Team RedTeam;

    [Header("Game objects")]
    // Pluck
    [SerializeField]
    private GameObject Pluck;
    [SerializeField]
    private Rigidbody PluckRigidBody;
    [SerializeField]
    private GameObject PluckSpawnPoint;
    
    // Blue stick
    [SerializeField]
    private GameObject BlueStick;
    [SerializeField]
    private GameObject BlueStickSpawnPoint;

    // Red stick
    [SerializeField]
    private GameObject RedStick;
    [SerializeField]
    private GameObject RedStickSpawnPoint;

    private static bool needReset;

    void Start()
    {
        BlueTeam = new Team("Blue", startLives, UIManager.instance.blueLivesComponent);
        RedTeam = new Team("Red", startLives, UIManager.instance.redLivesComponent);
    }

    private void Update()
    {
        if (BlueTeam.Lives == 0)
        {
            UIManager.instance.SetGameOver(TeamEnum.RED);
        }
        else if (RedTeam.Lives == 0)
        {
            UIManager.instance.SetGameOver(TeamEnum.BLUE);
        }

        if (needReset)
        {
            ResetField();
            needReset = false;
        }
    }

    private void ResetField()
    {
        Pluck.transform.position = PluckSpawnPoint.transform.position;
        PluckRigidBody.velocity = Vector3.zero;

        BlueStick.transform.position = BlueStickSpawnPoint.transform.position;
        RedStick.transform.position = RedStickSpawnPoint.transform.position;
    }

    public static void TeamLost(TeamEnum losingTeam)
    {
        Debug.Log(losingTeam.GetTeam().Name);
        losingTeam.GetTeam().Lives--;
        needReset = true;
    }
}
