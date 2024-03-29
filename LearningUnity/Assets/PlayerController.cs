﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask hitTheBoys;

    public Animator anim;

    public GameController gameController;

    public Player player;

    private bool performedAction = false;

    private bool movedHorizontal;

    public GameObject pauseMenu;

    public SpriteRenderer mySpriteRenderer;


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

    //New Stuff 2021-14-05



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
            updateParameters();
        }

        else if (!(player.getCurrentHP() <= 0))
        {
            if (gameController.getTurn() == true)
            {
                playerAction();
                updateParameters();
            }

            else
                print("Not player turn!");

            if (Input.GetKey(KeyCode.Escape))
            {
                openPauseMenu();
            }
        }
    }

    void openPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }

    void playerAction()
    {
        playerMove();
        playerAttack();
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

    void playerAttack()
    {
        if (Input.GetKeyDown("space"))
            basicAttack();

        else if
            (Input.GetKeyDown("tab"))
        {
            //Load menu for attacks
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
            performedAction = true;
        }
    }

    private void moveDown()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, -1f, 0f);
            performedAction = true;
        }
    }

    private void moveLeft()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
            performedAction = true;
        }
    }

    private void moveRight()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .45f, whatStopsMovement))
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
            performedAction = true;
        }
    }

    private void updateParameters()
    {
        updateAnimation();

        if (performedAction == true)
        {
            performedAction = false;
            gameController.endTurn();
            updateNourishmentAfterMove();
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

    void updateNourishmentAfterMove()
    {
        player.setNourishment((player.getNourishment() - 1));
    }

    void basicAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(movePoint.position, transform.TransformDirection(attackDirection()), 1.5f, hitTheBoys);

        if (hit)
        {
            gameController.flagForDamage(hit.transform.parent.gameObject, player.getAttack());
        }
        else
            print("Did not hit!");
        

        print("Player attacked!");

        performedAction = true;
    }

    Vector2 attackDirection()
    {
        Vector2 directionOfAttack = new Vector2(0f,0f);

        if (facing == direction.NORTH)
        {
            directionOfAttack = new Vector2(0f, 1f);
        }

        else if (facing == direction.NORTHEAST)
        {
            directionOfAttack = new Vector2(1f, 1f);
        }

        else if (facing == direction.EAST)
        {
            directionOfAttack = new Vector2(1f, 0f);
        }

        else if (facing == direction.SOUTHEAST)
        {
            directionOfAttack = new Vector2(1f, -1f);
        }

        else if (facing == direction.SOUTH)
        {
            directionOfAttack = new Vector2(0f, -1f);
        }

        else if (facing == direction.SOUTHWEST)
        {
            directionOfAttack = new Vector2(-1f, -1f);
        }

        else if (facing == direction.WEST)
        {
            directionOfAttack = new Vector2(-1f, 0f);
        }

        else if (facing == direction.NORTHWEST)
        {
            directionOfAttack = new Vector2(-1f, 1f);
        }

        return directionOfAttack;
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
            performedAction = true;
            if (player.getCurrentHP() > player.getMaxHP())
            {
                player.setCurrentHP(player.getMaxHP());
            }
        }

        if (performedAction == true)
        {
            performedAction = false;
            gameController.endTurn();
        }
     }

    public void eatFood()
    {
        if(player.getFoodAmount() > 0)
        {
            player.setNourishment(player.getNourishment() + 50);
            player.setFoodAmount(player.getFoodAmount() - 1);
            performedAction = true;
        }

        if (performedAction == true)
        {
            performedAction = false;
            gameController.endTurn();
        }

    }

    public void upgradeWeapon()
    {
        if (player.getUpgradeMaterials() > 0)
        {
            player.setAttack(player.getAttack() + 1);
            player.setUpgradeMaterials(player.getUpgradeMaterials() - 1);
            performedAction = true;
        }

        if (performedAction == true)
        {
            performedAction = false;
            gameController.endTurn();
        }
    }

}