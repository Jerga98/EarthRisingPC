using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePC : MonoBehaviour
{
    public GameObject tabletPanel;
    public GameObject Player;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)){
            if (!tabletPanel.activeInHierarchy)
            {
                tabletPanel.SetActive(true);
                //Player.transform.rotation.
            }
            else
            {
                tabletPanel.SetActive(false);
            }
        }
    }
}
