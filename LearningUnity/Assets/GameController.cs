using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TurnListener listener;

    public EnemyController[] enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (getTurn() == false)
        {
            enemyMove();
            endTurn();
        }
    }

    public void enemyMove()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].enemyMove();
        }
    }

    public void endTurn()
    {
        listener.endCurrentTurn();
    }

    public Boolean getTurn()
    {
        return listener.GetCurrentTurn();
    }
}
