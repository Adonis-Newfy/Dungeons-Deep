using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string unitName = "Yaboi";
    private int attack = 3;
    private int maxHP = 20;
    private int currentHP = 20;
    private int nourishment = 250;

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
}
