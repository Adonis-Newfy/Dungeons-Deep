using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUBPlayerController: MonoBehaviour
{

    public float moveSpeed = 5f;

    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public GameObject pauseMenu;

    //New Stuff 2021-04-05


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (pauseMenu.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                openPauseMenu();
            }
        }
        else
        {
            playerAction();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                openPauseMenu();
            }
        }
    }

    void openPauseMenu()
    {
        pauseMenu.SetActive(!(pauseMenu.activeSelf));
    }

    public void exitGame()
    {
        SceneManager.LoadScene(0);
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

    //New Stuff 2021-04-05


}
