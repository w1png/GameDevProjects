using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboGoal : MonoBehaviour
{
    [SerializeField]
    public TeamEnum teamEnum;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.transform.tag == "pluck")
        {
            PlayerManager.TeamScored(teamEnum);
        }
    }
}
