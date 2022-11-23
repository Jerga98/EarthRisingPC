
using UnityEngine;

[CreateAssetMenu(fileName = "RandomData", menuName = "RandomData")]
public class SpaceData : ScriptableObject
{
    public float randomData;
    public float lowNumber;
    public float highNumber;

    public void RandomGenerator()
    {
        randomData = Random.Range(lowNumber, highNumber);
    }

}   
