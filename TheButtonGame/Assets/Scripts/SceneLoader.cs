using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    private void OnEnable() {
        ExitBroadcast.NextLevel += LoadNextScene;
    }

    void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    

}
