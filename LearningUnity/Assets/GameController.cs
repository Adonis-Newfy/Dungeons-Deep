using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TurnListener listener;

    public EnemyController[] enemies;

    public Player player;

    public GameObject playerObject;

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

        if (checkLoseCondition() == true)
        {
            Destroy(playerObject);
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

    public void resolveEnemyAttack(int attack)
    {
        player.setCurrentHP(player.getCurrentHP() - attack);

        print("Player HP is: " + player.getCurrentHP());
    }

    private bool checkLoseCondition()
    {
        if (player.getNourishment() <= 0 || player.getCurrentHP() <= 0)
        {
            return true;
        }

        else
            return false;
    }
}
