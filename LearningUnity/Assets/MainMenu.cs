using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("MaxHealth", 20);
        PlayerPrefs.SetInt("CurrentHealth", 20);
        PlayerPrefs.SetInt("Attack", 3);
        PlayerPrefs.SetInt("Nourishment", 100);
        PlayerPrefs.SetInt("Currency", 0);
        PlayerPrefs.SetInt("PotionAmount", 0);
        PlayerPrefs.SetInt("FoodAmount", 0);
        PlayerPrefs.SetInt("MaterialsAmount", 0);
        PlayerPrefs.SetInt("StoredPotions", 1);
        PlayerPrefs.SetInt("StoredFood", 1);
        PlayerPrefs.SetInt("StoredMaterials", 1);

    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
