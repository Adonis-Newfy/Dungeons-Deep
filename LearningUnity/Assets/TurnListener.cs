using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    ADVANCE,
    DEATH
}


public class TurnListener : MonoBehaviour
{

    public gameState state;

    // Start is called before the first frame update
    void Start()
    {
        state = gameState.START;
    }

    void waitForPlayer()
    {
        while (state == gameState.PLAYERTURN)
        {
            //wait for player to do something
            //check to see
        }
    }

    void enemyTurn()
    {

    }

}