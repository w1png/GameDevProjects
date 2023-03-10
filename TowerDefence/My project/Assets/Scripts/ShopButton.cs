using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public BuildingBlueprint building;

    public void onClick()
    {
        Shop.Purchase(building);
    }
}
