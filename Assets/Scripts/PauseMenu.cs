using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseUI;

    public AudioSource ambiance;

    // Update is called once per frame
    void Update()
    {
        if(isPaused == false)
        {
            pauseUI.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
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
        ambiance.Play();
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        ambiance.Pause();
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
