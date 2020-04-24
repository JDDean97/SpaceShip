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
    //player stats UI
    public Healthbar playerHealth;      //how to properly retrieve the downloaded healthbar asset for use
    public Healthbar playerShield;
    public TextMeshProUGUI playerCredits;
    private int pCredits;

    //pause menu UI
    public GameObject pauseMenu;

    //upgrade menu UI
    public GameObject upgradeDialog;
    public GameObject upgradeMenu;

    //satellite where UpgradeMenu script is attached
    public GameObject satellite;
    private UpgradeMenu upgradeScript;

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
        playerCredits.text = "64500";       //exact amount of credits to buy every upgrade
        pCredits = Convert.ToInt32(playerCredits.text);

        upgradeScript = satellite.GetComponent<UpgradeMenu>();
        Debug.Log(pCredits);
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

        if (upgradeMenu.activeSelf)
        {
            //checking for upgrade to pause menu bug
            if (pauseMenu.activeSelf)
            {
                //when exiting pause menu, upgrade dialog will no longer show until player leaves trigger and re-enters -- needs fixing
                upgradeMenu.SetActive(false);
            }

            //add listener on buttons while upgrade menu is active
            upgradeScript.btnShield1.onClick.AddListener(delegate { Purchase(upgradeScript.shield1); });
            /*upgradeScript.btnShield2.onClick.AddListener(delegate { Purchase(upgradeScript.shield2); });
            upgradeScript.btnShield3.onClick.AddListener(delegate { Purchase(upgradeScript.shield3); });
            upgradeScript.btnLaser1.onClick.AddListener(delegate { Purchase(upgradeScript.laser1); });
            upgradeScript.btnLaser2.onClick.AddListener(delegate { Purchase(upgradeScript.laser2); });
            upgradeScript.btnLaser3.onClick.AddListener(delegate { Purchase(upgradeScript.laser3); });
            upgradeScript.btnRocket1.onClick.AddListener(delegate { Purchase(upgradeScript.rocket1); });
            upgradeScript.btnRocket2.onClick.AddListener(delegate { Purchase(upgradeScript.rocket2); });
            upgradeScript.btnRocket3.onClick.AddListener(delegate { Purchase(upgradeScript.rocket3); });*/
        }
        else 
        {
            upgradeScript.btnShield1.onClick.RemoveListener(delegate { Purchase(upgradeScript.shield1); });
            upgradeScript.btnShield2.onClick.RemoveListener(delegate { Purchase(upgradeScript.shield2); });
            upgradeScript.btnShield3.onClick.RemoveListener(delegate { Purchase(upgradeScript.shield3); });
            upgradeScript.btnLaser1.onClick.RemoveListener(delegate { Purchase(upgradeScript.laser1); });
            upgradeScript.btnLaser2.onClick.RemoveListener(delegate { Purchase(upgradeScript.laser2); });
            upgradeScript.btnLaser3.onClick.RemoveListener(delegate { Purchase(upgradeScript.laser3); });
            upgradeScript.btnRocket1.onClick.RemoveListener(delegate { Purchase(upgradeScript.rocket1); });
            upgradeScript.btnRocket2.onClick.RemoveListener(delegate { Purchase(upgradeScript.rocket2); });
            upgradeScript.btnRocket3.onClick.RemoveListener(delegate { Purchase(upgradeScript.rocket3); });
        }
    }

    void Purchase(int amount) 
    {
        if (pCredits >= amount)
        {
            String upgradeName = EventSystem.current.currentSelectedGameObject.name; //currently now broken -- after adding in the rest of the buttons (WHICH YOU HAVE TO ADD AUTOMATIC NAVIGATION TO, TO GET THE NAME OF OBJECT) it takes all 64,500 credits away on one purchase of the tier 1 shield
            Debug.Log(upgradeName);

            //determine which button was pressed to assign correct bool value
            //currently not very efficient, but working
            /*if (upgradeName == "btnShield1")
            {
                sUpgrade1 = true;
            }
            else if(upgradeName == "btnShield2") 
            {
                sUpgrade2 = true;
            }
            else if (upgradeName == "btnShield3")
            {
                sUpgrade3 = true;
            }
            else if (upgradeName == "btnLaser1")
            {
                lUpgrade1 = true;
            }
            else if (upgradeName == "btnLaser2")
            {
                lUpgrade2 = true;
            }
            else if (upgradeName == "btnLaser3")
            {
                lUpgrade3 = true;
            }
            else if (upgradeName == "btnRocket1")
            {
                rUpgrade1 = true;
            }
            else if (upgradeName == "btnRocket2")
            {
                rUpgrade2 = true;
            }
            else if (upgradeName == "btnRocket3")
            {
                rUpgrade3 = true;
            }*/
            pCredits -= amount;
            playerCredits.text = pCredits.ToString();
        }
        else 
        {
            //player does not have enough credits - display dialog window stating as such
        }
    }
}
