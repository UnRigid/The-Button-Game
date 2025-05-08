using UnityEngine;

public enum SoundType{
    ButtonPress
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    [SerializeField]private AudioClip[] SoundList;
    public static SoundManager instance;
    private AudioSource audioSource;

    private void Awake() {  
        instance=this;
        audioSource = GetComponent<AudioSource>();
    }


    public static void PlaySound(/* Sound to play; Volume */ SoundType sound){
        instance.audioSource.PlayOneShot(instance.SoundList[(int) sound], Settings.volume);
    }

}
