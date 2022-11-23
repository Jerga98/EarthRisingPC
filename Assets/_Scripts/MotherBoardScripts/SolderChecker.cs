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

    public void IsAllSolderComplete()
    {
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
        }
    }
}