using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUBPlayerController: MonoBehaviour
{

    public float moveSpeed = 5f;

    public Transform movePoint;

    public LayerMask whatStopsMovement;


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        playerAction();
    }

    void playerAction()
    {
        playerMove();
    }

    void playerMove()
    {
        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                moveRight();
            }

            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                moveLeft();
            }

            if (Input.GetAxisRaw("Vertical") == 1f)
            {
                moveUp();
            }

            else if (Input.GetAxisRaw("Vertical") == -1f)
            {
                moveDown();
            }
        }
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

}
