using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private Animator animator;
    private void Awake() {
        Settings.loadNextScene += LoadNextScene;
        animator = GameObject.FindGameObjectWithTag("BlackScreen").GetComponent<Animator>();

    }
    
   


    void LoadNextScene(){
        // System.GC.Collect();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
        animator.SetTrigger("LoadScene");



    }

    void OnDestroy()
    {
        Settings.loadNextScene -= LoadNextScene;
    }

}
