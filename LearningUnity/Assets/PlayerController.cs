using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public Animator anim;

    public GameController gameController;

    public Player player;

    private bool performedAction = false;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (gameController.getTurn() == true)
        {
            playerMove();
            if (performedAction == true)
            {
                performedAction = false;
                gameController.endTurn();
                updateNourishmentAfterMove();
            }
        }

        else
            print("Not player turn!");
    }

    void playerMove()
    {
        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                moveHorizontal();
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                moveVertical();
            }
        }
    }

    void moveHorizontal()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            performedAction = true;
        }
    }

    void moveVertical()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            performedAction = true;
        }
    }

    void updateNourishmentAfterMove()
    {
        player.setNourishment((player.getNourishment() - 1));
    }
}