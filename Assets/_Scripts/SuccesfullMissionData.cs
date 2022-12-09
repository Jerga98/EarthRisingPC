using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SuccesfullMissionData : MonoBehaviour
{
    [SerializeField] private SpaceData _randomData;
    [SerializeField] private int rarity;
    [SerializeField] private TMP_Text text;

    [BoxGroup("Data Name")] public string iron; //common
    [BoxGroup("Data Name")] public string copper; // common
    [BoxGroup("Data Name")] public string cobalt; // common
    [BoxGroup("Data Name")] public string water; //rare
    [BoxGroup("Data Name")] public string gold; // rare
    [BoxGroup("Data Name")] public string uranium; // rare
    [BoxGroup("Data Name")] public string unknown; // ultra rare

    [BoxGroup("Data Value")] public float ironData;
    [BoxGroup("Data Value")] public float copperData;
    [BoxGroup("Data Value")] public float cobaltData;
    [BoxGroup("Data Value")] public float waterData;
    [BoxGroup("Data Value")] public float goldData;
    [BoxGroup("Data Value")] public float uraniumData;
    [BoxGroup("Data Value")] public float unknownData;

    // private void Start()
    // {
    //     RandomMissionData();
    // }

    public void RandomMissionData()
    {
        text.text = null;

        if (ironData == 0)
        {
            int range = Random.Range(0, 100);

            if (range <= 90)
            {
                _randomData.RandomIronGenerator();
                ironData = _randomData.randomIronData;
                iron = ironData.ToString("F1");
                text.text = "Iron: " + iron;
            }
        }

        if (copperData == 0)
        {
            int range = Random.Range(0, 100);
            if (range <= 90)
            {
                _randomData.RandomCopperData();
                copperData = _randomData.randomCopperData;
                copper = copperData.ToString("F1");
                text.text += "\nCopper: " + copper;
            }
        }

        if (cobaltData == 0)
        {
            int range = Random.Range(0, 100);
            if (range <= 90)
            {
                _randomData.RandomCobaltData();
                cobaltData = _randomData.randomCobaltData;
                cobalt = cobaltData.ToString("F1");
                text.text += "\nCobalt: " + cobalt;
            }
        }

        if (waterData == 0)
        {
            int range = Random.Range(0, 100);
            if (range <= 40)
            {
                _randomData.RandomWaterData();
                waterData = _randomData.randomWaterData;
                water = waterData.ToString("F1");
                text.text += "\nWater: " + water;
            }
        }

        if (goldData == 0)
        {
            int range = Random.Range(0, 100);
            if (range <= 30)
            {
                _randomData.RandomGoldData();
                goldData = _randomData.randomGoldData;
                gold = goldData.ToString("F1");
                text.text += "\nGold: " + gold;
            }
        }

        if (uraniumData == 0)
        {
            int range = Random.Range(0, 100);
            if (range <= 15)
            {
                _randomData.RandomUraniumData();
                uraniumData = _randomData.randomUraniumData;
                uranium = uraniumData.ToString("F1");
                text.text += "\nUranium: " + uranium;
            }
        }

        if (unknownData == 0)
        {
            int range = Random.Range(0, 100);
            if (range <= 5)
            {
                _randomData.RandomUnknownData();
                unknownData = _randomData.randomUnknownData;
                unknown = unknownData.ToString("F1");
                text.text += "\nUnknown: " + unknown;
            }
        }

        // text.text = "Iron: " + iron + "\n" + "Copper: " + copper + "\n" + "Cobalt: " + cobalt +
        //             "\n" + "Water: " + water + "\n" + "Gold: " + gold + "\n" + "Uranium: "
        //             + uranium + "\n" + "Unknown: " + unknown;
    }
}
