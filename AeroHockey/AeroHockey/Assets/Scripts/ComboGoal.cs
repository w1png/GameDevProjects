using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboGoal : MonoBehaviour
{
    [SerializeField]
    public TeamEnum teamEnum;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("pluck"))
           PlayerManager.TeamLost(teamEnum);
    }
}
