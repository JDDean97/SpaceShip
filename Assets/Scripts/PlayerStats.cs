using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public Healthbar health;      //how to properly retrieve the downloaded healthbar asset for use
    public Healthbar shield;
    public TextMeshProUGUI credits;

    public bool damageTaken;
    public int timer;

    void Awake()
    {
        shield.health = GameManager.Instance.shield;
        shield.maximumHealth = 200;
        health.health = GameManager.Instance.health;
        credits.text = GameManager.Instance.credits.ToString();
        shield.healthPerSecond = GameManager.Instance.shieldPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.shield = shield.health;
        GameManager.Instance.health = health.health;
        credits.text = GameManager.Instance.credits.ToString();

        if (GameManager.Instance.sUpgrade3)
        {
            if (shield.health < shield.maximumHealth)
            {
                if (damageTaken == true)
                {
                    shield.regenerateHealth = false;
                    timer = GameManager.Instance.shieldTimerTillRegen;
                    StartCoroutine("shieldRegen");
                }
                else
                {
                    shield.healthPerSecond = GameManager.Instance.shieldPerSecond;
                    shield.regenerateHealth = true;
                    GameManager.Instance.shield = shield.health;
                }
            }
            else
            {
                shield.regenerateHealth = false;
                if (health.health < health.maximumHealth)
                {
                    health.healthPerSecond = 5;
                    health.regenerateHealth = true;
                }
                else
                {
                    health.regenerateHealth = false;
                }
            }
        }
        else if (GameManager.Instance.sUpgrade1)
        {
            if (shield.health < shield.maximumHealth - 50)
            {
                if (damageTaken == true)
                {
                    shield.regenerateHealth = false;
                    timer = GameManager.Instance.shieldTimerTillRegen;
                    StartCoroutine("shieldRegen");
                }
                else
                {
                    shield.healthPerSecond = GameManager.Instance.shieldPerSecond;
                    shield.regenerateHealth = true;
                    GameManager.Instance.shield = shield.health;
                }
            }
            else
            {
                shield.regenerateHealth = false;
                if (health.health < health.maximumHealth)
                {
                    health.healthPerSecond = 5;
                    health.regenerateHealth = true;
                }
                else
                {
                    health.regenerateHealth = false;
                }
            }
        }
        else
        {
            if (shield.health < shield.maximumHealth - 100)
            {
                if (damageTaken == true)
                {
                    shield.regenerateHealth = false;
                    timer = GameManager.Instance.shieldTimerTillRegen;
                    StartCoroutine("shieldRegen");
                }
                else
                {
                    shield.healthPerSecond = GameManager.Instance.shieldPerSecond;
                    shield.regenerateHealth = true;
                    GameManager.Instance.shield = shield.health;
                }
            }
            else
            {
                shield.regenerateHealth = false;
                if (health.health < health.maximumHealth)
                {
                    health.healthPerSecond = 5;
                    health.regenerateHealth = true;
                }
                else
                {
                    health.regenerateHealth = false;
                }
            }
        }

        //checking if player is dead
        if (shield.health <= shield.minimumHealth)
        {
            shield.health = shield.minimumHealth;
            if (health.health <= health.minimumHealth)
            {
                health.health = health.minimumHealth;
                GameManager.Instance.isDead = true;
            }
        }
    }

    public void damagePlayer(int amount)
    {
        if (shield.health > shield.minimumHealth)
        {
            shield.health -= amount;
            damageTaken = true;
        }
        else
        {
            health.health -= amount;
            damageTaken = true;
        }
    }

    IEnumerator shieldRegen()
    {
        yield return new WaitForSeconds(timer);

        damageTaken = false;

        StopCoroutine("shieldRegen");
    }
}
