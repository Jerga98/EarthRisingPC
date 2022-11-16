using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

public class RocketLaunch : MonoBehaviour
{
    private Animator animator;
    //private PreLaunchChecker _preLaunchChecker;
    CubeSatCheck cubeSatCheck;

    [SerializeField] Renderer rend;

    //[SerializeField] bool canLaunch;
    public SolderChecker launchable;

    private CheckAllChips[] _checkAllChipsArray;

    [BoxGroup("", ShowLabel = false)] [TitleGroup("/VFX")] [SerializeField]
    GameObject[] smoke;

    [BoxGroup("")] [TitleGroup("/VFX")] [SerializeField]
    GameObject[] explosion;

    [BoxGroup("")] [TitleGroup("/VFX")] [SerializeField]
    GameObject launchFire;

    private void Start()
    {
        animator = GetComponent<Animator>();
        launchFire.SetActive(false);
        foreach (GameObject _gameObject in explosion)
        {
            _gameObject.SetActive(false);
        }
        rend.enabled = true;
    }

    [ContextMenu("Launch Rocket")]
    public void OnButtonLaunchRocket()
    {
        if (CubeSatCheck.Launchable == true)
        {
            animator.SetBool("isTakeoff", true);
            foreach (GameObject _gameObject in smoke)
            {
                _gameObject.SetActive(false);
            }

            launchFire.SetActive(true);
            StartCoroutine(nameof(RocketLanding));
        }
        else
        {
            foreach (GameObject _gameObject in explosion)
            {
                _gameObject.SetActive(true);
            }
        }
    }
    
/*
    private void PreLaunchInspection()
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
    */

    IEnumerator RocketLanding()
    {
        yield return new WaitForSeconds(8);
        launchFire.SetActive(false);
        foreach (GameObject _gameObject in smoke)
        {
            _gameObject.SetActive(true);
        }

        animator.SetBool("isTakeoff", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            
        }
    }
}