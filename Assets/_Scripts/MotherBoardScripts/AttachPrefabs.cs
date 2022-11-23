using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AttachPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Transform parent;

    private TabletMechanics _tabletMechanics;

    private void Start()
    {
        _tabletMechanics = FindObjectOfType<TabletMechanics>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerSupply") && parentObject.gameObject.CompareTag("PowerSupply"))
        {

            if (!collision.transform.GetChild(1).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }

            else if (collision.transform.GetChild(0).gameObject.activeInHierarchy &&
                     !collision.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(1).gameObject.SetActive(true);
                //parentObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }
        }

        if (collision.gameObject.CompareTag("Payload_Controller") &&
            parentObject.gameObject.CompareTag("Payload_Controller"))
        {
            switch (prefab.gameObject.tag)
            {
                case "IC001":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "IC002":
                    collision.transform.GetChild(2).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "IC003":
                    collision.transform.GetChild(4).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "IC004":
                    collision.transform.GetChild(6).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "IC005":
                    collision.transform.GetChild(8).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "IC006":
                    collision.transform.GetChild(10).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("CubeSat") &&
            parentObject.gameObject.CompareTag("CubeSat"))
        {
            switch (prefab.gameObject.tag)
            {
                case "CubeSatSide":
                    for (int i = 0; i < 8; i++)
                    {
                        collision.transform.GetChild(i).gameObject.SetActive(true);
                        Destroy(prefab);
                    }

                    break;
            }
        }

        if (collision.gameObject.CompareTag("Electric Power Subsystem") &&
            parentObject.gameObject.CompareTag("Electric Power Subsystem"))
        {
            switch (prefab.gameObject.tag)
            {
                case "EPS_IC004":
                    collision.transform.GetChild(3).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "EPS_IC005":
                    collision.transform.GetChild(4).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                
            }
            
        }

        if (collision.gameObject.CompareTag("Cubesat Space Processor") &&
            parentObject.gameObject.CompareTag("Cubesat Space Processor"))
        {
            switch (prefab.gameObject.tag)
            {
                case "CSP_IC001":
                    collision.transform.GetChild(3).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("ICEPS Spacecraft System Core") &&
            parentObject.gameObject.CompareTag("ICEPS Spacecraft System Core"))
        {
            switch (prefab.gameObject.tag)
            {
                case "ICEPS_CPU":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "ICEPS_IC001":
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "ICEPS_IC004":
                    collision.transform.GetChild(4).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("iMTQ Magnetorquer") &&
            parentObject.gameObject.CompareTag("iMTQ Magnetorquer"))
        {
            switch (prefab.gameObject.tag)
            {
                case "iMTQ_IC001":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("ISIS_OnBoardComputer") &&
            parentObject.gameObject.CompareTag("ISIS_OnBoardComputer"))
        {
            switch (prefab.gameObject.tag)
            {
                case "ISIS_OBC_IC001":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "ISIS_OBC_IC002":
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("NANOobc-2_OBC") &&
            parentObject.gameObject.CompareTag("NANOobc-2_OBC"))
        {
            switch (prefab.gameObject.tag)
            {
                case "NANObc-2_ICU1":
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "NANObc-2_ICU2":
                    collision.transform.GetChild(2).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "NANObc-2_ICU3":
                    collision.transform.GetChild(3).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "Regulator_sensorT2":
                    collision.transform.GetChild(6).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("QubeAIS Receiver") &&
            parentObject.gameObject.CompareTag("QubeAIS Receiver"))
        {
            switch (prefab.gameObject.tag)
            {
                case "QubeAIS Receiver_CPU":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("S-Band High Data Rate Transmitter 1") &&
            parentObject.gameObject.CompareTag("S-Band High Data Rate Transmitter 1"))
        {
            switch (prefab.gameObject.tag)
            {
                case "S-Band_CPU":
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("NanoPower_BP4_PSU") && parentObject.gameObject.CompareTag("NanoPower_BP4_PSU"))
        {

            if (!collision.transform.GetChild(3).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(2).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(1).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }

            else if (collision.transform.GetChild(0).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(1).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(2).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(3).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(1).gameObject.SetActive(true);
                //parentObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }

            else if (collision.transform.GetChild(0).gameObject.activeInHierarchy &&
                collision.transform.GetChild(1).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(2).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(3).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(2).gameObject.SetActive(true);
                //parentObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }

            else if (collision.transform.GetChild(0).gameObject.activeInHierarchy &&
                collision.transform.GetChild(1).gameObject.activeInHierarchy &&
                collision.transform.GetChild(2).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(3).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(3).gameObject.SetActive(true);
                //parentObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }
        }

        if (collision.gameObject.CompareTag("NanoPower_P31u_PSU") && parentObject.gameObject.CompareTag("NanoPower_P31u_PSU"))
        {
            

            if (!collision.transform.GetChild(1).gameObject.activeInHierarchy &&
                !collision.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }

            else if (collision.transform.GetChild(0).gameObject.activeInHierarchy &&
                     !collision.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                collision.transform.GetChild(1).gameObject.SetActive(true);
                
                //parentObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(prefab);
            }
        }

        if (collision.gameObject.CompareTag("Satcom FM repeater") &&
            parentObject.gameObject.CompareTag("Satcom FM repeater"))
        {
            switch (prefab.gameObject.tag)
            {
                case "FM repeater_IC01":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "FM repeater_IC02":
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("Small Satellite On-board Computer") &&
            parentObject.gameObject.CompareTag("Small Satellite On-board Computer"))
        {
            switch (prefab.gameObject.tag)
            {
                case "Small Satellite OBC_CPU":
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "Small Satellite OBC_IC001":
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("UHF Radio SAT2RF1-1D") &&
            parentObject.gameObject.CompareTag("UHF Radio SAT2RF1-1D"))
        {
            switch (prefab.gameObject.tag)
            {
                case "UHF Radio_IC004":
                    collision.transform.GetChild(3).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }

        if (collision.gameObject.CompareTag("UHF_VHF_Duplex_Transceiver") &&
            parentObject.gameObject.CompareTag("UHF_VHF_Duplex_Transceiver"))
        {
            switch (prefab.gameObject.tag)
            {
                case "UHF_VHF_IC005":
                    collision.transform.GetChild(4).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
                case "UHF_VHF_IC006":
                    collision.transform.GetChild(5).gameObject.SetActive(true);
                    Destroy(prefab);
                    break;
            }
        }
    }
}