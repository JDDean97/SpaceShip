using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameManager;
    //private GameManager watcher;

    public GameObject pauseMenu;

    public AudioSource ambiance;
    public AudioSource engine;
    public AudioSource gg;

    // Start is called before the first frame update
    void Start()
    {
        //watcher = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*//regeneration
        if (watcher.playerShield.health < watcher.playerShield.maximumHealth) 
        {
            watcher.playerShield.healthPerSecond = -20;
            watcher.playerShield.ToggleRegeneration();
            watcher.playerHealth.healthPerSecond = -15;
            watcher.playerHealth.ToggleRegeneration();
        }
        else
        {
            if (watcher.playerHealth.health < watcher.playerHealth.maximumHealth) 
            {
                watcher.playerHealth.healthPerSecond = 5;
                watcher.playerHealth.ToggleRegeneration();
            }
        }

        //checking if player is dead
        if (watcher.playerShield.health <= watcher.playerShield.minimumHealth)
        {
            watcher.playerShield.health = watcher.playerShield.minimumHealth;
            if (watcher.playerHealth.health <= watcher.playerHealth.minimumHealth) 
            {
                watcher.playerHealth.health = watcher.playerHealth.minimumHealth;
                watcher.isDead = true;
                GameOver();
            }
        }*/
    }

    /*void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        pauseMenu.SetActive(false);
        ambiance.Pause();
        engine.Pause();
    }*/
}
