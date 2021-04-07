using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private string unitName = "GolemBoss";
    private int attack = 2;
    private int maxHP = 100;
    private int currentHP = 100;

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
