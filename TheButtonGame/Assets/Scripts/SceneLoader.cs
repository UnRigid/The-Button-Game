using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    private void OnEnable() {
        IntroLevel.LoadNext += LoadNextScene;
    }

    void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    

}
