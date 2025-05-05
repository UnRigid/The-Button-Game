using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteraction
{
    private Animator animator;
    

    private void Start() {
        animator = this.GetComponent<Animator>();
       
    }



    public void Interact(){
        animator.SetTrigger(-2075743765); // ID for animator parameter PressButton is -2075743765.
        
    }
}
