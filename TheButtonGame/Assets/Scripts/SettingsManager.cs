using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{

    
    [SerializeField]Toggle FullscreenToggle;
    [SerializeField]Button BackButton;
    [SerializeField]Slider VolumeSlider;
    [SerializeField]TMP_Text VolumeDisplay;

    void OnEnable()
    {
        VolumeSlider.value = Settings.volume;
        FullscreenToggle.isOn = true;    
        VolumeDisplay.text = "70%";    
    }


    public void GoBack(){
        SceneManager.LoadScene(0);
    }

    public void UpdateVolume(float SetVolume)
    {
        Settings.volume = SetVolume;
        VolumeDisplay.text = (Settings.volume * 100).ToString("00") + "%";
    }

    public void UpdateResolution(int ResInd){
        Settings.ResolutionIndex = ResInd;
    }

    public void UpdateFullscreen(bool IsFull){
        Screen.fullScreen = IsFull;
    }

}
