using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject playerInfo;
    public GameObject upgradeDialog;

    public AudioSource ambiance;    //ambient background noise
    public AudioSource engine;      //player's engine - audiosource is attached to the "ship" object
    public AudioSource pause;

    void Start() {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseUI.activeSelf)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        playerInfo.SetActive(true);
        ambiance.Play();
        engine.Play();
        pauseUI.SetActive(false);
        pause.Pause();
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        playerInfo.SetActive(false);
        if(upgradeDialog??false) 
        {
            upgradeDialog.SetActive(false);
        }
        ambiance.Pause();
        engine.Pause();
        pauseUI.SetActive(true);
        pause.Play();
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        pauseUI.SetActive(false);
        SceneManager.LoadSceneAsync(0);
    }
}
