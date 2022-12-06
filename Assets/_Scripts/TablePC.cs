using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePC : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject tabletPanel;
    public GameObject missionPanel;
    FirstPersonController firstPerson;

    private void Awake()
    {
        firstPerson = FindObjectOfType<FirstPersonController>();
    }
    private void Update()
    {
        if (Input.GetButtonUp("Tablet")){
            if (!tabletPanel.activeInHierarchy && !pausePanel.activeInHierarchy)
            {
                
                tabletPanel.SetActive(true);
                missionPanel.SetActive(true);
                firstPerson.CanMove = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("TABLET");
            }
            else if(tabletPanel.activeInHierarchy)
            {
                tabletPanel.SetActive(false);
                missionPanel.SetActive(false);
                firstPerson.CanMove = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("TABLET ugašen");
            }
        }
    }
}
