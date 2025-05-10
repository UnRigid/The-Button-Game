using System;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System.Collections;
public class IntroLevel : MonoBehaviour
{
    
    public static IntroLevel instance;

    static AudioSource audioSource;
    [SerializeField]AudioClip audioClip;
    string Subtitles = "Do not press the big red button.";
    static GameObject SubtitleObj;
    public static event Action LoadNext;

    private void Awake() {

        if(instance != null && instance != this){
            Destroy(this);
        }else{
            instance = this;
        }

        SubtitleObj = GameObject.FindGameObjectWithTag("Captions");
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        ExitBroadcast.Pressed_Button += PlayDialogue;
        SubtitleObj.SetActive(false);
        
    }
    private void Start() {
        
        Settings.initial_load = false;

        
        SaveManager.SaveSettings();   
        
    }

    private void PlayDialogue(){
        Play();
    }

    
    async void Play(){
        if(AudioListener.pause == true){
            Debug.Log("Some ting wong");
        }

        audioSource.PlayOneShot(audioClip, Settings.volume);
        SubtitleObj.GetComponent<TMP_Text>().text = Subtitles;
        SubtitleObj.SetActive(true);
        await Task.Delay((int)(audioClip.length * 1000));
        if(SubtitleObj != null){
            SubtitleObj.SetActive(false);

        }
        await Task.Delay(100);
        LoadNext?.Invoke();
        await Task.Yield();
    }

    private void OnDestroy() {
        ExitBroadcast.Pressed_Button -= PlayDialogue;
    }
}
