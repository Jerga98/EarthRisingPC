using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllChips : MonoBehaviour
{
    public SolderChecker[] _solderCheckers;
    int n = 0;
    public bool canLaunch;


    private void Start()
    {
        for (int i = 0; i < _solderCheckers.Length; i++)
        {
            _solderCheckers[i].IsAllSolderComplete();
        }
    }

    public void CheckAllComponents()
    {
        for (int i = 0; i < _solderCheckers.Length; i++)
        {
            if (!_solderCheckers[i].canLaunch)
            {
                n += 1;
            }
        }

        if (n == 0)
        {
            canLaunch = true;
            Debug.Log("Check ALl chips \n Can Launch " + canLaunch);
        }

        Debug.Log("Check all chips n " + n);
    }
}