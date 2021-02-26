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
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
            //movePoint.position += Vector3.MoveTowards(target.position, movePoint.position, moveSpeed * Time.deltaTime);
        }
        //GameEvents.current.playerAction();
    }
}
