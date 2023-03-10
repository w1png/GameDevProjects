using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static void Purchase(BuildingBlueprint item)
    {

        Debug.Log(PlayerManager.coins.ToString() + " " +  item.price.ToString());
        if (PlayerManager.coins < item.price)
        {
            UIManager.instance.errorText = "Not enough money to build!";
            return;
        }

        PlayerManager.coins -= item.price;
        BuildManager.instance.SetBuildingToBuild(item.prefab);
        return;

    }
}
