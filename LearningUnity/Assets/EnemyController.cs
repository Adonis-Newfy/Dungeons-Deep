using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject thisEnemy;

    public Transform movePoint;
    public Transform enemySprite;

    public LayerMask whatStopsMovement;

    public GameController gameController;

    public Transform target;

    public Enemy enemy;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        enemySprite.position = Vector3.MoveTowards(enemySprite.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (enemy.getCurrentHP() <= 0)
        {
            Destroy(thisEnemy);
        }
    }

    public void enemyMove()
    {
        if (active)
        {
            pursueTarget();
        }

        if (inRange(10f) == true)
        {
            becomeActive();
        }
    }

    private void pursueTarget()
    {
        if (inRange(1.5f) == true)
        {
            attackTarget();
        }

        else
        {
            if (targetXDifference() > targetYDifference())
            {
                if (target.position.x < this.movePoint.position.x)
                {
                    moveLeft();
                }

                else if (target.position.x > this.movePoint.position.x)
                {
                    moveRight();
                }
            }

            else if (targetYDifference() > targetXDifference())
            {
                if (target.position.y < this.movePoint.position.y)
                {
                    moveDown();
                }

                else if (target.position.y > this.movePoint.position.y)
                {
                    moveUp();
                }
            }
        }
    }

    private float targetXDifference()
    {
        float difference = Mathf.Abs(this.movePoint.position.x - target.position.x);

        return difference;
    }

    private float targetYDifference()
    {
        float difference = Mathf.Abs(this.movePoint.position.y - target.position.y);

        return difference;
    }

    private void moveUp()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, 1f, 0f);
        }
    }

    private void moveDown()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, -1f, 0f);
        }
    }

    private void moveLeft()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
        }
    }

    private void moveRight()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
        }
    }

    private void attackTarget()
    {
        print("Attacked player!");
        gameController.resolveEnemyAttack(enemy.getAttack());
    }
       
    private bool inRange(float range)
    {
        //1.5 Distance seems to work fine for now: might run into issues later.
        if (Vector3.Distance(target.position, this.movePoint.position) < range)
            return true;

        else
            return false;
    }

    private void becomeActive()
    {
        active = true;
    }
}
