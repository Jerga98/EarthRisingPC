using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionSO", menuName = "ScriptableObjects/MissionSO")]
public class MissionData : ScriptableObject
{
    [MultiLineProperty(10)] public string missionDetails;
    public GameObject[] prefabs;
    public string objectName;


}