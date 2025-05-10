using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    private void Start() {
        IntroLevel.LoadNext += LoadNextScene;

    }
   


    void LoadNextScene(){
        // System.GC.Collect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    

}
