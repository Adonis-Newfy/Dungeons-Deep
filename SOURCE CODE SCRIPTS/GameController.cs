﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public TurnListener listener;

    public List<EnemyController> enemies;

    public GolemBossController golemBoss;

    public Player player;

    public GameObject playerObject;

    public GameObject winConditionScreen;

    public bool gg = false;

    public GameObject loseScreen;

    public GameObject healText;
    public GameObject nourishmentText;

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
            if (golemBoss != null)
            {
                bossMove();
            }
            enemyMove();
            endTurn();
        }

        if (checkLoseCondition() == true)
        {
            loseScreen.SetActive(true);

        }

        checkWinCondition();
    }

    public void bossMove()
    {
        golemBoss.bossAction();
        print(golemBoss.golem.getCurrentHP());
    }

    public void checkWinCondition()
    {
        if (enemies.Count == 0 && golemBoss == null)
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
        if (golemBoss != null && enemy == golemBoss.gameObject)
        {
            if (golemBoss.playerBuffed() == true)
            {
                damage += 20;
            }
            golemBoss.golem.setCurrentHP(golemBoss.golem.getCurrentHP() - damage);

            golemBoss.dropHammer();
        }

        else
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
    }

    public void checkEnemyStatus()
    {
        if (golemBoss != null)
        {
            if (golemBoss.isAlive() == false)
            {
                player.setCurrency(player.getCurrency() + 200);
                //PlayerPrefs.SetInt("MaxHealth", player.getMaxHP() + 10);
                player.setMaxHP(player.getMaxHP() + 10);
                Destroy(golemBoss.movePoint.gameObject);
                Destroy(golemBoss.thisEnemy);
            }
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].isAlive() == false)
            {
                player.setCurrency(player.getCurrency() + enemies[i].enemy.getValue());
                Destroy(enemies[i].movePoint.gameObject);
                Destroy(enemies[i].thisEnemy);
                enemies.RemoveAt(i);

                //Add some sort of enemies.getValue() rather than increasing currency by a flat amount
                
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
        if (player.getNourishment() <= 0)
        {
            healText.SetActive(false);
            nourishmentText.SetActive(true);
            return true;
        }
        
        else if (player.getCurrentHP() <= 0)
        {
            healText.SetActive(true);
            nourishmentText.SetActive(false);
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
