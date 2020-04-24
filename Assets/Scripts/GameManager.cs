using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //player stats UI
    public Healthbar playerHealth;      //how to properly retrieve the downloaded healthbar asset for use
    public Healthbar playerShield;
    public TextMeshProUGUI playerCredits;
    public int pCredits;

    public bool isDead;
    public bool gameWon;

    //player upgrades
    public bool sUpgrade1;
    public bool sUpgrade2;
    public bool sUpgrade3;
    public bool lUpgrade1;
    public bool lUpgrade2;
    public bool lUpgrade3;
    public bool rUpgrade1;
    public bool rUpgrade2;
    public bool rUpgrade3;

    // Start is called before the first frame update
    void Start()
    {
        //initialize player variables
        isDead = false;
        gameWon = false;
        sUpgrade1 = false;
        sUpgrade2 = false;
        sUpgrade3 = false;
        lUpgrade1 = false;
        lUpgrade2 = false;
        lUpgrade3 = false;
        rUpgrade1 = false;
        rUpgrade2 = false;
        rUpgrade3 = false;
        playerHealth.health = 50;
        playerShield.health = 50;
        playerCredits.text = "22500";       //exact amount of credits to buy every upgrade
        pCredits = Convert.ToInt32(playerCredits.text);
    }

    // Update is called once per frame
    void Update() {
        //regeneration
        if (playerShield.health < playerShield.maximumHealth) 
        {
            playerShield.healthPerSecond = 20;
            playerShield.ToggleRegeneration();
        }
        else
        {
            if (playerHealth.health < playerHealth.maximumHealth) 
            {
                playerHealth.healthPerSecond = 5;
                playerHealth.ToggleRegeneration();
            }
        }

        //checking if player is dead
        if (playerShield.health <= playerShield.minimumHealth)
        {
            playerShield.health = playerShield.minimumHealth;
            if (playerHealth.health <= playerHealth.minimumHealth) 
            {
                playerHealth.health = playerHealth.minimumHealth;
                isDead = true;
            }
        }
    }
}
