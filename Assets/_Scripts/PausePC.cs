using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePC : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausePanel;
    public GameObject tabletPanel;
    public GameObject missionPanel;

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
        tabletPanel.SetActive(false);
        missionPanel.SetActive(false);
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
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
