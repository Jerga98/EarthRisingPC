using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SolderChecker : MonoBehaviour
{
    public OnContactChangeColor[] contactChangeColors;
    public int n = 0;
    public bool canLaunch;

    private void Update()
    {
        //IsAllSoderComplete();
    }

    public void IsAllSoderComplete()
    {
        Debug.Log("poæinje SolderChecker");
        Debug.Log("SolderChecker radi");
        for (int i = 0; i < contactChangeColors.Length; i++)
        {
            if (contactChangeColors[i].isFinished == false)
            {
                n += 1;
            }
        }
        if (n == 0)
        {
            canLaunch = true;
            Debug.Log("SolderCh n usporedba je: " + canLaunch);
        }
        Debug.Log("Solder n: " + n);
    }
}