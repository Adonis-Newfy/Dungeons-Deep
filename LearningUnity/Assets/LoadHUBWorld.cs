using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHUBWorld : MonoBehaviour
{
    public void LoadLevel()
    {
        PlayerPrefs.SetInt("Currency", 0);
        SceneManager.LoadScene(1);
    }
}
