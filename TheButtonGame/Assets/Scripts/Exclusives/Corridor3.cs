using UnityEngine;

public class Corridor3 : MonoBehaviour
{
    
    public static Corridor3 instance;

    [SerializeField]AudioClip audioClip;

    string Dialogue = "";

    static AudioSource audioSource;
    static GameObject Captions;


    private void Awake() {
        if(instance != null && instance != this){
            Destroy(instance);
        }else{
            instance = this;
        }

        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        Captions = GameObject.FindGameObjectWithTag("Captions");
    }


    



}
