
using UnityEngine;

[CreateAssetMenu(fileName = "RandomData", menuName = "RandomData")]
public class SpaceData : ScriptableObject
{
    public float lowNumber;
    public float highNumber;

    public float randomIronData,
        randomCopperData,
        randomCobaltData,
        randomWaterData,
        randomGoldData,
        randomUraniumData,
        randomUnknownData;


    public void RandomIronGenerator()
    {
        randomIronData = Random.Range(lowNumber, highNumber);
    }

    public void RandomCopperData()
    {

        randomCopperData = Random.Range(lowNumber, highNumber);
    }

    public void RandomCobaltData()
    {

        randomCobaltData = Random.Range(lowNumber, highNumber);
    }

    public void RandomWaterData()
    {

        randomWaterData = Random.Range(lowNumber, highNumber);
    }

    public void RandomGoldData()
    {

        randomGoldData = Random.Range(lowNumber, highNumber);
    }

    public void RandomUraniumData()
    {

        randomUraniumData = Random.Range(lowNumber, highNumber);
    }

    public void RandomUnknownData()
    {

        randomUnknownData = Random.Range(lowNumber, highNumber);
    }
}   
