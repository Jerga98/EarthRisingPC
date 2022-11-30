using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer mainMixer;

    private void Update()
    {
        SetQ();
    }
    public void SetQ()
    {
        SetScreenRes();        
    }

    public void LoadGameScene()
    {
        if(PlayerPrefs.GetInt("FirstTime") == 0)
        {
            SceneManager.LoadScene(1); //uèitaj scenu tutoriala
        }
        else
        {
            SceneManager.LoadScene(2); //uèitaj scenu ingamea
        }
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

    void SetScreenRes()
    {
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (index)
        {
            case "800x600":
                Screen.SetResolution(800, 600, true);
                break;
            case "1024x768":
                Screen.SetResolution(1024, 768, true);
                break;
            case "1280x800":
                Screen.SetResolution(1280, 800, true);
                break;
            case "1366x768":
                Screen.SetResolution(1366, 768, true);
                break;
            case "1280x1024":
                Screen.SetResolution(1280, 1024, true);
                break;
            case "1440x900":
                Screen.SetResolution(1440, 900, true);
                break;
            case "1680x1050":
                Screen.SetResolution(1680, 1050, true);
                break;
            case "1980x1080,":
                Screen.SetResolution(1980, 1080, true);
                break;
            case "2560x1440":
                Screen.SetResolution(2560, 1440, true);
                break;
            case "3840x2160":
                Screen.SetResolution(3840, 2160, true);
                break;
        }
    }
}
