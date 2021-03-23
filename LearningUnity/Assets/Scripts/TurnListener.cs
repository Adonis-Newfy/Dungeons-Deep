using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnListener : MonoBehaviour
{
    //True when currently players turn, false otherwise.
    private Boolean isPlayerTurn;

    private void Start()
    {
        //GameEvents.current.onPlayerAction += OnPlayerTurn;
        //GameEvents.current.onEnemyAction += OnEnemyTurn;

        this.isPlayerTurn = true;
    }
    public Boolean GetCurrentTurn()
    {
        return isPlayerTurn;
    }

    public void endCurrentTurn()
    {
        this.isPlayerTurn = !isPlayerTurn;
    }
}