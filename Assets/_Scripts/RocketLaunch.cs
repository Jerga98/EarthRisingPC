using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private SpaceData _spaceData_SO;
    private Animator animator;

    CubeSatCheck cubeSatCheck;

    [SerializeField] Renderer rend;

    private CheckAllChips[] _checkAllChipsArray;

    [BoxGroup("", ShowLabel = false)] [TitleGroup("/VFX")] [SerializeField]
    GameObject[] smoke;

    [BoxGroup("")] [TitleGroup("/VFX")] [SerializeField]
    GameObject[] explosion;

    [BoxGroup("")] [TitleGroup("/VFX")] [SerializeField]
    GameObject launchFire;

    private MissionList _missionList;
    private SuccesfullMissionData _succesfullMissionData;
    private SuccesfullMisionScore _succesfullMisionScore;

    private void Awake()
    {
        cubeSatCheck = FindObjectOfType<CubeSatCheck>();
        _missionList = FindObjectOfType<MissionList>();
        animator = GetComponent<Animator>();
        _succesfullMissionData = FindObjectOfType<SuccesfullMissionData>();
    }

    private void Start()
    {
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
        if (cubeSatCheck.launchable)
        {
            _missionList.ResetMission();
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

            _missionList.ResetMission();
        }
    }

    IEnumerator RocketLanding()
    {
        yield return new WaitForSeconds(8);
        launchFire.SetActive(false);
        foreach (GameObject _gameObject in smoke)
        {
            _gameObject.SetActive(true);
        }

        cubeSatCheck.launchable = false;
        animator.SetBool("isTakeoff", false);
        _succesfullMissionData.RandomMissionData();
        Invoke(nameof(GetScore), 2);
    }

    private void GetScore()
    {
        _succesfullMisionScore.MissionScore();
    }
}