using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamworksIntegration : MonoBehaviour
{
    private void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(1084440);
            PrintYourName();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void PrintYourName()
    {
        Debug.Log(Steamworks.SteamClient.Name);
    }
}
