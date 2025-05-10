using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class SpecialInteractions : MonoBehaviour
{

    Camera cameraComp;
    bool Button = false;
    bool Corner = false;
    static TMP_Text Captions;
    [SerializeField] AudioClip[] DialogueClips;
    static AudioSource audioSource;

    public static SpecialInteractions instance;

    string[] dialogue = {"Wow you really aren't even a little interested in what's behind that cool corner?", 
    "Yeah there's actually nothing over here.", 
    "So there's actually nothing over here and you're stuck forever.",
    "Well I guess that didn't work."};

    private void Awake() {

        if(instance != null && instance != this){
            Destroy(this);
        }else{
            instance = this;
        }

        cameraComp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Captions = GameObject.FindGameObjectWithTag("Captions").GetComponent<TMP_Text>();
        Captions.transform.gameObject.SetActive(false);
        Captions.text = "";

        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }
    

    private void Update() {
        SeePOI();
    }

    void SeePOI(){
        switch(CheckView().name){

            
            
            case "ColliderButton": //Looking at the button
                
                //Button == 0 && Corner == 0: Havent looked at either, set Button to true, I = 0
                if( !Button && !Corner ){
                    Button = true;
                    PlayDialogue(0);
                    

                    //play dialogue
                }
                //Button == 0 && Corner == 1: Have looked at corner, normal sequence, I = 3
                else if(!Button && Corner){
                    //Play dialogue
                    PlayDialogue(3);
                    Button = true;
                }
                //Button == 1 && Corner == 1: Second sequence, do nothing
                
                //Button == 1 && Corner == 0: nothing

            break;

            case "ColliderCross":  //Looking at the Corner
                if(!Button && !Corner){
                    Corner = true;
                    PlayDialogue(2);
                    //play dialogue, I = 2
                }
                else if(Button && !Corner){
                    Corner = true;
                    PlayDialogue(1);
                    //play dialogue, I = 1
                }
            break;

            default:
            break;
        }
    }

    async void PlayDialogue(int Index){
        Captions.text = dialogue[Index];
        Captions.transform.gameObject.SetActive(true);
        if(audioSource.isPlaying){
            audioSource.Stop();

        }
        //Play Sound
        audioSource.PlayOneShot(DialogueClips[Index], Settings.volume);
        await Task.Delay((int) (DialogueClips[Index].length * 1000));
        if(Captions.transform.gameObject != null){
            Captions.transform.gameObject.SetActive(false);

        }
        await Task.Yield();
    }


    GameObject CheckView(){
        
        
        Ray ray = cameraComp.ViewportPointToRay(new Vector3(0.5f , 0.5f , 0));
        if(Physics.Raycast(ray, out RaycastHit hit)){
            return hit.transform.gameObject;
        }else{
            return gameObject;
        }
        
        

    }

}
