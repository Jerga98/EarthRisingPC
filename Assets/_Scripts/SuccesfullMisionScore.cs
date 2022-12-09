using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SuccesfullMisionScore : MonoBehaviour
{
    /*Summary
     s - solders
     p - components 
     v - time
     r - Score
     
     r = (p + s) / v * 10000
     
     successful mission gives additional 50 points
     */

    [SerializeField] private float score;
    [SerializeField] private float numberOfSolders;
    [SerializeField] public float numberOfComponents;
    [SerializeField] private float timeFinished;

    public GameObject cubeSat;

    private CubeSatComposition _cubeSatComposition;
    private SolderChecker _solderChecker; //Number of solders 
    private CubeSatCheck _cubeSatCheck; //Number of components ( cubesat children - 6)
    private TimerAdding _timer;

    private void Awake()
    {
        _solderChecker = FindObjectOfType<SolderChecker>();
        _cubeSatCheck = FindObjectOfType<CubeSatCheck>();
        _timer = FindObjectOfType<TimerAdding>();
        _cubeSatComposition = FindObjectOfType<CubeSatComposition>();
    }

    [ContextMenu("Mission Score")]
    public void MissionScore()
    {
        var chips = cubeSat.GetComponentInChildren<CheckAllChips>();
        for (int i = 0; i < chips._solderCheckers.Length; i++)
        {
            numberOfSolders = i;
            Debug.Log($"Solders {numberOfSolders}");
        }


        // ovaj dio jos ne radi kako treba
        // cilj je da izbroji sve komponente koje u sebi imaju AllChips.cs skriptu
        var components = _cubeSatCheck._allChips;
        for (int i = 0; i < components.Count; i++)
        {
            numberOfComponents = i;
        }

        timeFinished = _timer.timerCounter;
        float seconds = Mathf.FloorToInt(timeFinished % 60);

        score = (numberOfComponents + numberOfSolders) / seconds * 100;
        Debug.Log(
            $"Number of solders {numberOfSolders} \nComponents {numberOfComponents} \nScore {score} \nTime {timeFinished}");
    }
}