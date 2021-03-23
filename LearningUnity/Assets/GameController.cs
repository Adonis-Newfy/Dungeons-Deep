using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TurnListener listener;

    public List<EnemyController> enemies;

    public Player player;

    public GameObject playerObject;

    public GameObject winConditionScreen;

    public bool gg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkEnemyStatus();

        if (getTurn() == false)
        {
            enemyMove();
            endTurn();
        }

        if (checkLoseCondition() == true)
        {
            print("Game Over.");
        }

        checkWinCondition();
    }

    public void checkWinCondition()
    {
        if (enemies.Count == 0)
        {
            gg = true;
        }

        if (gg == true)
        {
            winConditionScreen.SetActive(true);
        }
    }

    public void flagForDamage(GameObject enemy, int damage)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemy == enemies[i].gameObject)
            {
                enemies[i].enemy.setCurrentHP(enemies[i].enemy.getCurrentHP() - damage);
                print("Enemy " + enemies[i].gameObject + " hp is: " + enemies[i].enemy.getCurrentHP());
            }

            else
            {
                print("Could not cross-compare enemy.");
            }
        }
    }

    public void checkEnemyStatus()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].isAlive() == false)
            {
                Destroy(enemies[i].movePoint.gameObject);
                Destroy(enemies[i].thisEnemy);
                enemies.RemoveAt(i);
            }
        }
    }

    public void enemyMove()
    {
        for (int i = 0; i < enemies.Count; i++)
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

    /*
    private void removeFromArray(int index)
    {
        EnemyController[] newArray = new EnemyController[enemies.Length - 1];

        for (int i = 0; i < enemies.Length; i++)
        {
            if (i != index)
            {
                newArray[i] = enemies[i];
            }
        }

        enemies = newArray;
    }
    */

}
