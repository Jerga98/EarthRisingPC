using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPC : MonoBehaviour
{
    RocketLaunch rocketLaunch;
    public GameObject launchPanel;

    private void Awake()
    {
        rocketLaunch = FindObjectOfType<RocketLaunch>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            launchPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && launchPanel.activeInHierarchy)
        {
            Debug.Log("Radi E");
            rocketLaunch.OnButtonLaunchRocket();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            launchPanel.SetActive(false);
        }
    }
}
