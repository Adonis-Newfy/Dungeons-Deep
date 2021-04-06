using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDVariables : MonoBehaviour
{

    public TMP_Text health;
    public TMP_Text nourishment;
    public TMP_Text attack;
    public TMP_Text potions;
    public TMP_Text food;
    public TMP_Text upgradeMaterials;
    public TMP_Text currency;
    public TMP_Text direction;

    public PlayerController playerObject;

    public Player player;

    // Update is called once per frame
    void Update()
    {
        health.text = "" + player.getCurrentHP();
        nourishment.text = "" + player.getNourishment();
        attack.text = "" + player.getAttack();
        potions.text = "" + player.getPotionCount();
        food.text = "" + player.getFoodAmount();
        upgradeMaterials.text = "" + player.getUpgradeMaterials();
        currency.text = "" + player.getCurrency();
        direction.text = "" + playerObject.getDirection();
    }
}
