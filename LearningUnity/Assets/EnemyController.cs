using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform movePoint;
    public Transform enemySprite;

    public LayerMask whatStopsMovement;

    public GameController gameController;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        enemySprite.position = Vector3.MoveTowards(enemySprite.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void enemyMove()
    {
        pursueTarget();
    }

    private void pursueTarget()
    {
        if (inRange() == true)
        {
            attackTarget();
        }

        else
        {
            if (target.position.x < this.movePoint.position.x)
            {
                moveLeft();
            }

            else if (target.position.x > this.movePoint.position.x)
            {
                moveRight();
            }

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

    private void moveUp()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, 1f, 0f);
        }
    }

    private void moveDown()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, -1f, 0f);
        }
    }

    private void moveLeft()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
        }
    }

    private void moveRight()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
        }
    }

    private void attackTarget()
    {
        //TODO: implement attack functionality.
        print("Attacked player!");
    }
       
    private bool inRange()
    {
        //1.5 Distance seems to work fine for now: might run into issues later.
        if (Vector3.Distance(target.position, this.movePoint.position) < 1.5)
            return true;

        else
            return false;
    }
}
