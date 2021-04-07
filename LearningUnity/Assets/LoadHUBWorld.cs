using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHUBWorld : MonoBehaviour
{
    public void loadHUBWorld()
    {
        PlayerPrefs.SetInt("Currency", 0);
        SceneManager.LoadScene(1);
    }

    public void loadBossLevel()
    {
        SceneManager.LoadScene(3);
    }
}
