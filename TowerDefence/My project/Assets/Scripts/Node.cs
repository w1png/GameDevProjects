using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color materialColor;

    private GameObject building;
    public Vector3 positionOffset;
    public TextMeshProUGUI errorText;

    private Renderer rendererComponent;

    private void Start()
    {
        errorText = GameObject.Find("ErrorText").GetComponent<TextMeshProUGUI>();
        errorText.CrossFadeAlpha(0f, 0f, true);

        rendererComponent = GetComponent<Renderer>();
        materialColor = rendererComponent.material.color;
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(0)) return;

        if (Input.GetMouseButtonDown(1))
        {
            if (building == null)
            {
                StartCoroutine(DrawError("There is no building on this node!"));
                return;
            }
            Destroy(building);
            return;
        }

        if (building != null)
        {
            StartCoroutine(DrawError("This node is already occupied!"));
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        building = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation) as GameObject;
        return;

    }


    IEnumerator DrawError(string error)
    {
        errorText.text = error;
        errorText.CrossFadeAlpha(1f, 0.3f, true);
        yield return new WaitForSeconds(0.6f);
        errorText.CrossFadeAlpha(0f, 0.3f, true);
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
