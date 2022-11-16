using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLerp : MonoBehaviour
{
    private MeshRenderer cubeMeshRenderer;
    [SerializeField] private Color[] _colors;
    [SerializeField] [Range(0, 1)] private float lerpTime;

    private int colorIndex;
    private float time = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cubeMeshRenderer.material.color =
            Color.Lerp(cubeMeshRenderer.material.color, _colors[colorIndex], lerpTime * Time.deltaTime);


        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
        if (time > .9f)
        {
            //time = 0;
            colorIndex++;
            colorIndex = (colorIndex >= _colors.Length) ? 0 : colorIndex;
            
        }
    }
    
}