using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : StateMachineBehaviour
{
    bool FirstLoad = true;


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(animator.gameObject.name == "Play"){
        if(!FirstLoad){
            SceneManager.LoadScene("Saves");
        }else{
            SceneManager.LoadScene("Corridor1");
        }
       }else if(animator.gameObject.name == "Quit"){
            Application.Quit();
       }
       else{
            SceneManager.LoadScene(animator.gameObject.name);
       }
    }

    
}
