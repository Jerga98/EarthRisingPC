using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePC : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausePanel;

    FirstPersonController firstPerson;

    private void Awake()
    {
        firstPerson = FindObjectOfType<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                firstPerson.CanMove = true;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                firstPerson.CanMove = false;
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Options()
    {
        //open options panel...
    }

    public void BackToMenu()
    {
        //Load menu scene...
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
