using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject playerStats;

    public AudioSource ambiance;
    public AudioSource engine;
    public AudioSource gg;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isDead)
        {
            playerDead();
        }
    }

    void playerDead()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        pauseMenu.SetActive(false);
        playerStats.SetActive(false);
        ambiance.Pause();
        engine.Pause();
    }
}
