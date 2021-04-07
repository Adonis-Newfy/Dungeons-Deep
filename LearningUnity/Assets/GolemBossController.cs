using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossController : MonoBehaviour
{

    public GameObject thisEnemy;
    public Golem golem;

    public GameController gameController;

    public Transform target;
    public Transform movePoint;

    public List<Transform> inner;
    public List<Transform> outer;

    public List<Transform> hammers;

    public Animator anim;

    int autoAttackTimer = 0;
    bool aoeDamage = false;

    bool playerHasHammer = false;

    int aoeCounter = 0;

    bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateAnimation();
    }

    public void playerInAoE(bool inAoE)
    {
        aoeDamage = inAoE;
    }

    public void resolveAoE()
    {
        aoeDamage = false;
    }

    public void pickUpHammer()
    {
        playerHasHammer = true;
        hammers[0].parent.gameObject.SetActive(false);
    }

    public void dropHammer()
    {
        playerHasHammer = false;
    }

    public bool playerBuffed()
    {
        return playerHasHammer;
    }

    private void updateAnimation()
    {
        if (attacking == true)
        {
            anim.SetBool("isAttacking", true);
        }

        else
            anim.SetBool("isAttacking", false);
    }


    public bool isAlive()
    {
        return (golem.getCurrentHP() >= 0);
    }

    //Returns true if the timer for the AoE has counted down.
    public bool timerUp()
    {
        return aoeDamage;
    }

    public void bossAction()
    {
        handleAutoTimer();

        attacking = false;

        if (aoeCounter == 5)
        {
            inner[0].parent.gameObject.SetActive(true);
        }

        if (aoeCounter == 10)
        {
            if (aoeDamage == true)
            {
                aoeAttack();
            }

            inner[0].parent.gameObject.SetActive(false);
            outer[0].parent.gameObject.SetActive(true);
        }

        if (aoeCounter == 15)
        {
            if (aoeDamage == true)
            {
                aoeAttack();
            }

            outer[0].parent.gameObject.SetActive(false);
            hammers[0].parent.gameObject.SetActive(true);

            aoeCounter = 0;
        }

        if (autoAttackTimer == 4)
        {
            attacking = true;
        }

        if (inRange(3f) == true && autoAttackTimer == 5)
        {
            //if player is in melee range, smack them (2 damage)
            attackTarget();
        }

        else if (autoAttackTimer == 5)
        {
            //if player is not in melee range, and auto counter reaches 5, throw a rock (1 damage)
            attackTargetRanged();
        }
    }

    private void handleAutoTimer()
    {
        if (autoAttackTimer == 5)
        {
            autoAttackTimer = 0;
        }

        else
            autoAttackTimer += 1;

        aoeCounter += 1;
    }

    public void aoeAttack()
    {
        print("Player hit by aoe!");
        gameController.resolveEnemyAttack(10);
    }

    private void attackTarget()
    {
        print("Attacked player!");
        gameController.resolveEnemyAttack(golem.getAttack());
    }

    private void attackTargetRanged()
    {
        print("Attacked player!");
        gameController.resolveEnemyAttack(golem.getAttack() / 2);
    }

    private bool inRange(float range)
    {
        //1.5 Distance seems to work fine for now: might run into issues later.
        if (Vector3.Distance(target.position, this.movePoint.position) < range)
            return true;

        else
            return false;
    }
}
