using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PreLaunchChecker : MonoBehaviour
{
    [BoxGroup("", ShowLabel = false)] [TitleGroup("/VFX")] [SerializeField]
    GameObject[] smoke;

    [BoxGroup("")] [TitleGroup("/VFX")] [SerializeField]
    GameObject[] explosion;

    [BoxGroup("")] [TitleGroup("/VFX")] [SerializeField]
    GameObject launchFire;

    private CheckAllChips[] _checkAllChipsArray;
    public bool _isLaunchable;


    private void Start()
    {
        foreach (GameObject _gameObject in explosion)
        {
            _gameObject.SetActive(false);
        }
    }

    public void PreLaunchInspection()
    {
        for (int i = 0; i < _checkAllChipsArray.Length; i++)
        {
            //if (launchable.canLaunch)
            if (_checkAllChipsArray[i].canLaunch)
            {
                _isLaunchable = true;
            }
            else
            {
                _isLaunchable = false;
                foreach (GameObject _gameObject in smoke)
                {
                    _gameObject.SetActive(false);
                }

                foreach (GameObject _gameObject in explosion)
                {
                    _gameObject.SetActive(true);
                }
                //rend.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            PreLaunchInspection();
        }
    }
}