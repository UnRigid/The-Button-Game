using UnityEngine;
using System.Threading.Tasks;

public enum SoundType
{
    ButtonPress,
    Walk,
    OpenDoor
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    [SerializeField]private AudioClip[] SoundList;
    public static SoundManager instance;
    private AudioSource audioSource;

    private void Awake() {  
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }


    async void PlayFootsteps()
    {   
        int 
        instance.audioSource.PlayOneShot(instance.SoundList[1], Settings.volume);
        await Task.Delay((int)(instance.SoundList[1].length * 1000));
    }

    public static void PlaySound(/* Sound to play; Volume */ SoundType sound)
    {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)sound], Settings.volume);
    }

}
