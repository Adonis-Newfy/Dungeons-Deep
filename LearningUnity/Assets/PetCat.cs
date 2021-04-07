using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCat : MonoBehaviour
{
    public GameObject catMenu;
    public GameObject panelA;
    public GameObject panelB;

    public Animator anim;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            catMenu.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("PlayerInRange", false);
            catMenu.SetActive(false);
            panelA.SetActive(true);
            panelB.SetActive(false);
        }
    }

    public void petCat()
    {
        anim.SetBool("PlayerInRange", true);
    }
}
