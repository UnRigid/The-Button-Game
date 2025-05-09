using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuTransition : MonoBehaviour
{
    

    

    public void Clicked(GameObject thisObject){
        switch(thisObject.name){
            case"Play":
                if(Settings.initial_load){
                    Settings.initial_load = false;
                    SceneManager.LoadScene("Corridor1");

                }else{
                    SceneManager.LoadScene("Saves");
                }
                break;
            case"Settings":
                Settings.OriginIndex = 0;
                SceneManager.LoadScene("Settings");
                break;
            case"Credits":
                SceneManager.LoadScene("Credits");
                break;
            case"Quit":
                Application.Quit();
                break;
            default:
                Debug.LogWarning(thisObject.name + " Does not exist.");
                break;
       } 
    }
    

    
}
