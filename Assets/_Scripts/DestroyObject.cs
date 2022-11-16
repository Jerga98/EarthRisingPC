using System;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private GameObject clone;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other = clone.GetComponent<Collider>();
        
        if (!other.gameObject.CompareTag("GameController") || !other.gameObject.CompareTag("solderingIron"))
        {
            Destroy(other.gameObject);
        }
    }
}