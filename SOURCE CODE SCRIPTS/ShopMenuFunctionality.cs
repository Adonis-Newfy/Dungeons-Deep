using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenuFunctionality : MonoBehaviour
{
    public Player player;

    public void increasePotions()
    {
        if (player.getCurrency() >= 25)
        {
            player.setPotionCount(player.getPotionCount() + 1);
            player.setCurrency(player.getCurrency() - 25);
        }
    }

    public void increaseFood()
    {
        if (player.getCurrency() >= 10)
        {
            player.setFoodAmount(player.getFoodAmount() + 1);
            player.setCurrency(player.getCurrency() - 10);
        }

    }

    public void increaseUpgradeMaterials()
    {
        if (player.getCurrency() >= 50)
        {
            player.setUpgradeMaterials(player.getUpgradeMaterials() + 1);
            player.setCurrency(player.getCurrency() - 50);
        }

    }
}
