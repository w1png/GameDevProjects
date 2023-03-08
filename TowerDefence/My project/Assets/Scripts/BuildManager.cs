using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1 build manager on the scene.");
            return;
        }

        instance = this;
    }
    public BuildManager GetInstance()
    {
        return instance;
    }


    public GameObject turretPrefab;
    private GameObject turretToBuild;

    private void Start()
    {
        turretToBuild = turretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
