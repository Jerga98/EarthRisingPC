using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePC : MonoBehaviour
{
    public GameObject tabletPanel;
    FirstPersonController firstPerson;

    private void Awake()
    {
        firstPerson = FindObjectOfType<FirstPersonController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)){
            if (!tabletPanel.activeInHierarchy)
            {
                tabletPanel.SetActive(true);
                firstPerson.CanMove = false;
                Cursor.visible = true;
            }
            else
            {
                tabletPanel.SetActive(false);
                firstPerson.CanMove = true;
                Cursor.visible = false;
            }
        }
    }
}
