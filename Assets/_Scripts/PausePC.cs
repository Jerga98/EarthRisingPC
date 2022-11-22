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
            }
            else
            {
                Pause();

            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        firstPerson.CanMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        firstPerson.CanMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
