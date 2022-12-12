using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnContactChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer cubeMeshRenderer;
    [SerializeField] private Color[] _colors;
    [SerializeField] [Range(0, 1)] private float lerpTime;
    public static bool tutorialIsFinished;
    public float numberOfSolders;

    private int colorIndex;
    private float time = 0;

    public bool isFinished;

    private void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("solderingIron") && !isFinished)
        {
            cubeMeshRenderer.material.color =
                Color.Lerp(cubeMeshRenderer.material.color, _colors[colorIndex], lerpTime * Time.deltaTime);


            time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
            if (time > 0.98f)
            {
                colorIndex++;

                //colorIndex = (colorIndex >= _colors.Length) ? 0 : colorIndex;

                if (colorIndex >= _colors.Length)
                {
                    colorIndex = 0;
                    isFinished = true;
                    tutorialIsFinished = true;
                }

                if (isFinished)
                {
                    numberOfSolders++;
                }
            }
        }
    }
}