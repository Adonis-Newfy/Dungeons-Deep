using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StorageMenuFunctionality : MonoBehaviour
{

    public int potionCount = 0;
    public int foodCount = 0;
    public int upgradeMaterialCount = 0;

    public TMP_Text potions;
    public TMP_Text food;
    public TMP_Text upgradeMaterials;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        potionCount = PlayerPrefs.GetInt("StoredPotions");
        foodCount = PlayerPrefs.GetInt("StoredFood");
        upgradeMaterialCount = PlayerPrefs.GetInt("StoredMaterials");
    }

    // Update is called once per frame
    void Update()
    {
        potions.text = "" + potionCount;
        food.text = "" + foodCount;
        upgradeMaterials.text = "" + upgradeMaterialCount;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("StoredPotions", potionCount);
        PlayerPrefs.SetInt("StoredFood", foodCount);
        PlayerPrefs.SetInt("StoredMaterials", upgradeMaterialCount);
    }

    public void depositPotion()
    {
        if (player.getPotionCount() >= 1)
        {
            player.setPotionCount(player.getPotionCount() - 1);
            potionCount = potionCount + 1;
        }
    }

    public void depositFood()
    {
        if (player.getFoodAmount() >= 1)
        {
            player.setFoodAmount(player.getFoodAmount() - 1);
            foodCount = foodCount + 1;
        }
    }

    public void depositUpgradeMaterials()
    {
        if (player.getUpgradeMaterials() >= 1)
        {
            player.setUpgradeMaterials(player.getUpgradeMaterials() - 1);
            upgradeMaterialCount = upgradeMaterialCount + 1;
        }
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
