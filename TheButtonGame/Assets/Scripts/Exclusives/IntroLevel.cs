using System;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
public class IntroLevel : MonoBehaviour
{
    
    AudioSource audioSource;
    [SerializeField]AudioClip audioClip;
    string Subtitles = "Do not press the big red button.";
    [SerializeField]GameObject SubtitleObj;
    public static event Action LoadNext;

    private void Awake() {
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        ExitBroadcast.Pressed_Button += PlayDialogue;
        SubtitleObj.SetActive(false);
        Debug.Log("hello");
    }
    private void Start() {
        
        Settings.initial_load = false;

        
        SaveManager.SaveSettings();   
        
    }

    private void PlayDialogue(){
        Play();
        
    }

    async void Play(){
        audioSource.PlayOneShot(audioClip, Settings.volume);
        SubtitleObj.GetComponent<TMP_Text>().text = Subtitles;
        SubtitleObj.SetActive(true);
        await Task.Delay((int)(audioClip.length * 1000));
        SubtitleObj.SetActive(false);
        await Task.Delay(100);
        LoadNext?.Invoke();
        await Task.Yield();
    }

}
