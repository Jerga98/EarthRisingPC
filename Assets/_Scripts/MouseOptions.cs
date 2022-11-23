using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOptions : MonoBehaviour
{
    public Slider mouseSensitivitySlider;
    private void Start()
    {
        
    }
    public void SetMouseSensitivity(float val)
    {
        if (Application.isPlaying) return;
        PlayerPrefs.SetFloat("Sensitivity", val);
    }
}
