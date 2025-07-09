using UnityEngine;
using System.Threading.Tasks;

public enum SoundType
{
    ButtonPress,
    OpenDoor,
    OpenCage
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    [SerializeField]private AudioClip[] SoundList;
    public static SoundManager instance;
    private AudioSource audioSource;


    private void Awake()
    {
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


    public static void PlayCustomSound(AudioClip sound)
    {
        instance.audioSource.PlayOneShot(sound, Settings.volume);
    }

    public static bool IsPlaying()
    {
        if (instance.audioSource.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public static void PlaySound(/* Sound to play; Volume */ SoundType sound)
    {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)sound], Settings.volume);
    }

}
