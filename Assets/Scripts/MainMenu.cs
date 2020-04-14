using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject aboutMenu;

    void Start()
    {
        //on load display correct hierarchy of UI
        mainMenu.SetActive(true);
        aboutMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
