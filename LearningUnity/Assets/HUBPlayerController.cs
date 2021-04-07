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

    public Animator anim;

    public SpriteRenderer mySpriteRenderer;

    //New Stuff 2021-04-05

    public Player player;

    private enum direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,

        NORTHEAST,
        NORTHWEST,
        SOUTHEAST,
        SOUTHWEST
    }

    direction facing = direction.SOUTH;

    bool movedHorizontal = false;




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
            updateAnimation();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                openPauseMenu();
            }
        }
    }

    void updateAnimation()
    {
        if (facing == direction.NORTH)
        {
            anim.SetBool("WalkNorth", true);
            anim.SetBool("WalkSouth", false);
            anim.SetBool("WalkWest", false);
        }

        else if (facing == direction.SOUTH)
        {
            anim.SetBool("WalkSouth", true);
            anim.SetBool("WalkNorth", false);
            anim.SetBool("WalkWest", false);
        }

        else if (facing == direction.WEST)
        {
            anim.SetBool("WalkWest", true);
            if (mySpriteRenderer.flipX == true)
            {
                mySpriteRenderer.flipX = false;
            }
            anim.SetBool("WalkSouth", false);
            anim.SetBool("WalkNorth", false);
        }

        else if (facing == direction.EAST)
        {
            anim.SetBool("WalkWest", true);
            if (mySpriteRenderer.flipX == false)
            {
                mySpriteRenderer.flipX = true;
            }
            anim.SetBool("WalkSouth", false);
            anim.SetBool("WalkNorth", false);
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

            if (Input.GetKey(KeyCode.LeftShift))
            {
                adjustDirection();
            }

            else
            {
                if (Input.GetAxisRaw("Horizontal") == 1f)
                {
                    moveRight();
                    facing = direction.EAST;
                    movedHorizontal = true;
                }

                else if (Input.GetAxisRaw("Horizontal") == -1f)
                {
                    moveLeft();
                    facing = direction.WEST;
                    movedHorizontal = true;
                }

                if (Input.GetAxisRaw("Vertical") == 1f)
                {
                    moveUp();
                    if (movedHorizontal == true)
                    {
                        if (facing == direction.EAST)
                        {
                            facing = direction.NORTHEAST;
                        }
                        else
                            facing = direction.NORTHWEST;
                    }

                    else
                        facing = direction.NORTH;
                }

                else if (Input.GetAxisRaw("Vertical") == -1f)
                {
                    moveDown();
                    if (movedHorizontal == true)
                    {
                        if (facing == direction.EAST)
                        {
                            facing = direction.SOUTHEAST;
                        }
                        else
                            facing = direction.SOUTHWEST;
                    }

                    else
                        facing = direction.SOUTH;
                }


                movedHorizontal = false;
            }
        }
    }

    private void adjustDirection()
    {
        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            facing = direction.EAST;
            movedHorizontal = true;
        }

        else if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            facing = direction.WEST;
            movedHorizontal = true;
        }

        if (Input.GetAxisRaw("Vertical") == 1f)
        {
            if (movedHorizontal == true)
            {
                if (facing == direction.EAST)
                {
                    facing = direction.NORTHEAST;
                }
                else
                    facing = direction.NORTHWEST;
            }

            else
                facing = direction.NORTH;
        }

        else if (Input.GetAxisRaw("Vertical") == -1f)
        {
            if (movedHorizontal == true)
            {
                if (facing == direction.EAST)
                {
                    facing = direction.SOUTHEAST;
                }
                else
                    facing = direction.SOUTHWEST;
            }

            else
                facing = direction.SOUTH;
        }

        movedHorizontal = false;
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

    public string getDirection()
    {
        return facing.ToString();
    }

    public void drinkPotion()
    {
        if (player.getPotionCount() > 0)
        {
            player.setCurrentHP(player.getCurrentHP() + 10);
            player.setPotionCount(player.getPotionCount() - 1);
            if (player.getCurrentHP() > player.getMaxHP())
            {
                player.setCurrentHP(player.getMaxHP());
            }
        }
    }

    public void eatFood()
    {
        if (player.getFoodAmount() > 0)
        {
            player.setNourishment(player.getNourishment() + 50);
            player.setFoodAmount(player.getFoodAmount() - 1);
        }
    }

    public void upgradeWeapon()
    {
        if (player.getUpgradeMaterials() > 0)
        {
            player.setAttack(player.getAttack() + 1);
            player.setUpgradeMaterials(player.getUpgradeMaterials() - 1);
        }
    }

}
