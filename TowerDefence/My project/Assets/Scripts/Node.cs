using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color materialColor;
    public Vector3 positionOffset;
    public TextMeshProUGUI errorText;

    private GameObject currentBuilding;
    private Renderer rendererComponent;
    private UIManager uiManager;

    private void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        materialColor = rendererComponent.material.color;
        uiManager = UIManager.instance;
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(0)) return;

        if (Input.GetMouseButtonDown(1))
        {
            if (currentBuilding == null)
            {
                uiManager.errorText = "There is no building on this node!";
                return;
            }
            Destroy(currentBuilding);
            return;
        }

        if (currentBuilding != null)
        {
            uiManager.errorText = "This node is already occupied!";
            return;
        }

        GameObject buildingToBuild = BuildManager.instance.GetBuildingToBuild();
        if (buildingToBuild == null)
        {
            uiManager.errorText = "No building selected!";
            return;
        }

        currentBuilding = Instantiate(buildingToBuild, transform.position + positionOffset, transform.rotation) as GameObject;
        BuildManager.instance.SetBuildingToBuild(null);
    }
    
    void OnMouseEnter()
    {
        rendererComponent.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rendererComponent.material.color = materialColor;
    }
}
