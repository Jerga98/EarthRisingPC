using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSatCheck : MonoBehaviour
{
    CheckAllChips allChips;
    [SerializeField] public static bool Launchable = false;
    private void OnTriggerEnter(Collider other)
    {

        allChips = FindObjectOfType<CheckAllChips>();
        Debug.Log("poèinje CUbeSatCheck");
        allChips.CheckAllComponents();
        Debug.Log("CUbeSatCheck radi");

        if (other.gameObject.CompareTag("CubeSat"))
        {
            if(other.gameObject.GetComponentInChildren<CheckAllChips>().canLaunch == true)
            {
                Launchable = true;
            }
            
        }
        Destroy(other);
    }
}
