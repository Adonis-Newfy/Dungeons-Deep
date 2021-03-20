using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string unitName = "EvilBob";
    private int attack = 1;
    private int maxHP = 5;
    private int currentHP = 5;

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

}

