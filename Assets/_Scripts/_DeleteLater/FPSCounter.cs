using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
   [SerializeField] private Text fpsText;
   [SerializeField] private float deltaTime;

   private void Update()
   {
      deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
      float fps = 1.0f / deltaTime;
      fpsText.text = Mathf.Ceil(fps).ToString();
   }
}
