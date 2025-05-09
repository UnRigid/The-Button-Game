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
    [SerializeField]Slider SensitivitySlider;
    [SerializeField]TMP_Text SensitivityDisplay;

    void OnEnable()
    {
        VolumeSlider.value = Settings.volume;
        FullscreenToggle.isOn = true;    
        VolumeDisplay.text = (Settings.volume * 100).ToString("00") + "%";  
        SensitivityDisplay.text = (Settings.Sensitivity * 100).ToString("00") + "%";
        SensitivitySlider.value = Settings.Sensitivity;  
    }


    public void GoBack(){
        SaveManager.SaveSettings();
        SceneManager.LoadScene(Settings.OriginIndex);
    }

    public void UpdateVolume(float SetVolume)
    {
        Settings.volume = SetVolume;
        VolumeDisplay.text = (Settings.volume * 100).ToString("00") + "%";
    }

    public void UpdateSensitivity(float SetSensitivity)
    {
        Settings.Sensitivity = SetSensitivity;
        SensitivityDisplay.text = (Settings.Sensitivity * 100).ToString("00") + "%";
    }

    public void UpdateResolution(int ResInd){
        Settings.ResolutionIndex = ResInd;
    }

    public void UpdateFullscreen(bool IsFull){
        Screen.fullScreen = IsFull;
    }

    public void WipeS(){
        SaveManager.Wipe();
    }

}
