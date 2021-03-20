using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    abstract public int getMaxHP();

    abstract public int getAttack();

    abstract public int getCurrentHP();

    abstract public string getUnitName();

    abstract public void setName(string name);

    abstract public void setMaxHP(int hp);

    abstract public void setAttack(int att);

    abstract public void setCurrentHP(int hp);
}
