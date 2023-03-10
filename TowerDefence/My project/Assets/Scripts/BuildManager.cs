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

    private GameObject buildingToBuild;
    public void SetBuildingToBuild(GameObject building)
    {
        buildingToBuild = building;
    }
    public GameObject GetBuildingToBuild()
    {
        return buildingToBuild;
    }
}
