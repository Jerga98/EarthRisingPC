using System;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Collider started");
        //other = clone.GetComponent<Collider>();

        if (!other.gameObject.CompareTag("GameController") && !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera") && !other.gameObject.CompareTag("solderingIron"))
            {
            Debug.Log(other.gameObject);

            Destroy(other.gameObject);
            Debug.Log("Object destroyed");
        }
    }
}