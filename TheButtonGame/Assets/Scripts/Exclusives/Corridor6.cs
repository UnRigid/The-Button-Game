using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Corridor6 : MonoBehaviour
{
    public static Corridor6 instance;

    [SerializeField] AudioClip[] audioClip;

    string[] Dialogue = {"dialogue1","dialogue2"};

    static AudioSource audioSource;
    static GameObject Captions;


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

        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        Captions = GameObject.FindGameObjectWithTag("Captions");
        Captions.SetActive(false);


        ExitBroadcast.Pressed_Button += PlayPressed;

        PlayInitial();
    }

    async void PlayInitial()
    {
        Captions.GetComponent<TMP_Text>().text = Dialogue[0];
        Captions.SetActive(true);
        audioSource.PlayOneShot(audioClip[0], Settings.volume);
        await Task.Delay((int)(audioClip[0].length * 1000));
        Captions.SetActive(false);
        await Task.Yield();
    }

    async void PlayPressed()
    {
        Captions.GetComponent<TMP_Text>().text = Dialogue[1];
        Captions.SetActive(true);
        audioSource.PlayOneShot(audioClip[1], Settings.volume);
        await Task.Delay((int)(audioClip[1].length * 1000));
        Captions.SetActive(false);
        Settings.Load();
        await Task.Yield();
    }

    private void OnDestroy() {
        ExitBroadcast.Pressed_Button -= PlayPressed;
    }
}
