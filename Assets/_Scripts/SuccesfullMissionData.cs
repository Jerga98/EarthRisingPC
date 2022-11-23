using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuccesfullMissionData : MonoBehaviour
{
    [SerializeField] private SpaceData _spaceData_SO;
    [SerializeField] private TMP_Text text;
    public string iron;
    public float ironData;
    public string copper;
    public float copperData;

    private void Start()
    {
        RandomMissionData();
    }

    public void RandomMissionData()
    {
        if (ironData == 0)
        {
            _spaceData_SO.RandomGenerator();
            ironData = _spaceData_SO.randomData;
            iron = ironData.ToString("F1");
        }

        if (copperData == 0)
        {
            _spaceData_SO.RandomGenerator();
            copperData = _spaceData_SO.randomData;
            copper = copperData.ToString("F1");
        }

        text.text = "Iron: " + iron + "\n" + "Copper: " + copper;
    }
}
