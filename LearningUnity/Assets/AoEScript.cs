using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEScript : MonoBehaviour
{
    public GolemBossController boss;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.playerInAoE(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.playerInAoE(false);
        }
    }
}
