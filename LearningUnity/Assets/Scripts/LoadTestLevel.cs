using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTestLevel : MonoBehaviour
{
    public GameObject contextMenu;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            contextMenu.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        contextMenu.SetActive(false);
    }
}
