using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTutorial : MonoBehaviour
{
    public GameObject triggerCube;
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            triggerCube.SetActive(false);
        }
    }
}
