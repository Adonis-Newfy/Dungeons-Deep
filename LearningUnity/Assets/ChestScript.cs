using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestScript : MonoBehaviour
{
    public int potionCount;
    public int foodCount;
    public int upgradeMaterialCount;

    public Player player;

    public TMP_Text potions;
    public TMP_Text food;
    public TMP_Text upgradeMaterials;

    void Update()
    {
        potions.text = "" + potionCount;
        food.text = "" + foodCount;
        upgradeMaterials.text = "" + upgradeMaterialCount;
    }
    public void withdrawPotion()
    {
        if (potionCount >= 1)
        {
            player.setPotionCount(player.getPotionCount() + 1);
            potionCount = potionCount - 1;
        }
    }

    public void withdrawFood()
    {
        if (foodCount >= 1)
        {
            player.setFoodAmount(player.getFoodAmount() + 1);
            foodCount = foodCount - 1;
        }
    }

    public void withdrawUpgradeMaterials()
    {
        if (upgradeMaterialCount >= 1)
        {
            player.setUpgradeMaterials(player.getUpgradeMaterials() + 1);
            upgradeMaterialCount = upgradeMaterialCount - 1;
        }
    }
}
