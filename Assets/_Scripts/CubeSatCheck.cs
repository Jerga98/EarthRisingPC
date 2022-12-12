using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSatCheck : MonoBehaviour
{
    [SerializeField] public List<CheckAllChips> _allChips;
    [SerializeField] public GameObject cubeSat;
    public bool launchable;
    public static bool launchableTutorial;

    private SuccesfullMisionScore _succesfullMisionScore;

    private void Start()
    {
        _succesfullMisionScore = FindObjectOfType<SuccesfullMisionScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //for (int i = 0; i < _allChips.Count; i++)
        //{
        //    _allChips[i].CheckAllComponents();
        //}

        //if (other.gameObject.CompareTag("CubeSat"))
        //{
        //    if (other.gameObject.GetComponentInChildren<CheckAllChips>())
        //    {
        //        launchable = true;
        //        launchableTutorial = true;
        //    }
        //}

        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("CubeSat"))
        {
            cubeSat = other.gameObject;
            _succesfullMisionScore.cubeSat = cubeSat;

            var addChips = cubeSat.GetComponentsInChildren<CheckAllChips>();
            _succesfullMisionScore.numberOfComponents = addChips.Length;

            for (int i = 0; i < addChips.Length; i++)
            {
                addChips[i].CheckAllComponents();
            }

            if (other.gameObject.GetComponentInChildren<CheckAllChips>())
            {
                launchable = true;
                launchableTutorial = true;
            }
        }

        StartCoroutine(DestroyObject());
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(20);
        Destroy(cubeSat);
    }

}