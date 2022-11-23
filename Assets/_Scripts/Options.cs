using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [Header("MouseSen")]

    public AudioMixer mainMixer;


    public void SeTFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    //Sound preko audio mixera
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

}
