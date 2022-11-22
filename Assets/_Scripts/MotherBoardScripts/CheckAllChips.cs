using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllChips : MonoBehaviour
{
    public SolderChecker[] _solderCheckers;
    public SolderChecker SolderChecker;
    int n = 0;
    public bool canLaunch;

    private void Update()
    {
        //CheckAllComponents();
    }

    public void CheckAllComponents()
    {
        //SolderChecker = FindObjectOfType<SolderChecker>();
        //Debug.Log("poèinje CheckAllChips");
        //SolderChecker.IsAllSoderComplete();
        //Debug.Log("CheckAllChips radi");

        for (int i = 0; i < _solderCheckers.Length; i++)
        {
            _solderCheckers[i].IsAllSoderComplete();
            if (_solderCheckers[i].canLaunch == false)
            {
                Debug.Log(_solderCheckers[i].canLaunch);
                n += 1;
            }

        }
        if (n == 0)
        {
            canLaunch = true;
            Debug.Log("ChAllCh n usporedba je: " + canLaunch);
        }
        Debug.Log("Chip n: " + n);
    }
}
