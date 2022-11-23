using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ApplyGraphics()
    {
       //Screen.fullScreen 
    }

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
