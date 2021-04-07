using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string unitName = "Yaboi";
    private int attack;
    private int maxHP;
    private int currentHP;
    private int nourishment;
    private int currency;

    //New Stuff 2021-04-05

    private int foodAmount = 5;
    private int potionCount = 5;
    private int upgradeMaterials = 5;

    void Start()
    {
        attack = PlayerPrefs.GetInt("Attack");
        maxHP = PlayerPrefs.GetInt("MaxHealth");
        currentHP = PlayerPrefs.GetInt("MaxHealth");
        nourishment = PlayerPrefs.GetInt("Nourishment");
        currency = PlayerPrefs.GetInt("Currency");
        foodAmount = PlayerPrefs.GetInt("FoodAmount");
        potionCount = PlayerPrefs.GetInt("PotionAmount");
        upgradeMaterials = PlayerPrefs.GetInt("MaterialsAmount");

    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("MaxHealth", maxHP);
        PlayerPrefs.SetInt("Attack", attack);
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetInt("PotionAmount", potionCount);
        PlayerPrefs.SetInt("FoodAmount", foodAmount);
        PlayerPrefs.SetInt("MaterialsAmount", upgradeMaterials);
    }
    public int getMaxHP()
    {
        return maxHP;
    }

    public int getAttack()
    {
        return attack;
    }

    public int getCurrentHP()
    {
        return currentHP;
    }

    public string getUnitName()
    {
        return unitName;
    }

    public int getNourishment()
    {
        return nourishment;
    }

    public void setName(string name)
    {
        unitName = name;
    }

    public void setMaxHP(int hp)
    {
        maxHP = hp;
    }

    public void setAttack(int att)
    {
        attack = att;
    }

    public void setCurrentHP(int hp)
    {
        currentHP = hp;
    }

    public void setNourishment(int n)
    {
        nourishment = n;
    }

    //New Stuff 2021-04-05

    public int getFoodAmount()
    {
        return foodAmount;
    }

    public int getPotionCount()
    {
        return potionCount;
    }

    public int getUpgradeMaterials()
    {
        return upgradeMaterials;
    }

    public int getCurrency()
    {
        return currency;
    }

    public void setFoodAmount(int food)
    {
        foodAmount = food;
    }

    public void setPotionCount(int potion)
    {
        potionCount = potion;
    }

    public void setUpgradeMaterials(int upgrades)
    {
        upgradeMaterials = upgrades;
    }

    public void setCurrency(int gold)
    {
        currency = gold;
    }
}
