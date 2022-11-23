using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissionList : MonoBehaviour
{
    [BoxGroup("Prefabs")] [SerializeField] private GameObject transform;
    [BoxGroup("Prefabs")] [SerializeField] private TMP_Text missiontexts;

    [BoxGroup("Mission Data")] [SerializeField]
    private List<MissionData> _missionData;

    private MissionData currentMissionData;


    private void Start()
    {

        ResetMission();
    }

    [ContextMenu("Reset Mission")]
    public void ResetMission()
    {
        int children = transform.transform.childCount;

        if (children >= 5)
        {
            foreach (Transform child in transform.transform)
            {
                Destroy(child.gameObject);
            }
        }

        MissionPicker();
    }

    private void MissionPicker()
    {
        int randomNumber;
        randomNumber = Random.Range(0, _missionData.Count);
        int index = -1;
        for (int i = 0; i < _missionData.Count; i++)
        {
            index = i;

            if (index == randomNumber)
            {
                GameObject[] gameObjects;
                gameObjects = _missionData[index].prefabs;
                for (int k = 0; k < gameObjects.Length; k++)
                {
                    _missionData[k].objectName = gameObjects[k].name;
                    TMP_Text temptext = Instantiate(missiontexts, transform.transform);

                    temptext.text = _missionData[k].objectName;
                }
            }
        }
    }
}