using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuTransition : MonoBehaviour
{
    bool FirstLoad = true;

    

    public void Clicked(GameObject thisObject){
        switch(thisObject.name){
            case"Play":
                if(FirstLoad){
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
