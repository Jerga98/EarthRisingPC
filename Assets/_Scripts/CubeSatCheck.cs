using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSatCheck : MonoBehaviour
{
    [SerializeField] List<CheckAllChips> _allChips;
    public bool launchable;
    public static bool launchableTutorial;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _allChips.Count; i++)
        {
            _allChips[i].CheckAllComponents();
        }

        if (other.gameObject.CompareTag("CubeSat"))
        {
            if (other.gameObject.GetComponentInChildren<CheckAllChips>())
            {
                launchable = true;
                launchableTutorial = true;
            }
        }

        Destroy(other.gameObject);
    }
    
}