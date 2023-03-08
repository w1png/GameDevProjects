using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = waypoints.Length - 1; i >= 0; i--)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
