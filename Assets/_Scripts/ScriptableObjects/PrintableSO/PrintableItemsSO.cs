using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsToPrint", menuName = "ScriptableObjects/PrintableItems")]
public class PrintableItemsSO : ScriptableObject
{
    public Sprite sprite;
    public float timeToInstantiate;
    public GameObject prefab;
    public string objectName;
    [InfoBox("Short description of an object and where does it belong")]
    [Title("Description", bold: false)]
    [HideLabel]
    [MultiLineProperty(20)] public string description;


}
