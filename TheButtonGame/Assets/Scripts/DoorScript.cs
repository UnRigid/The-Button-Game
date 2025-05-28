using UnityEngine;

public class DoorScript : MonoBehaviour , IInteraction
{

    private Animator animator;

    private void Awake()
    {
        animator = this.transform.parent.gameObject.GetComponent<Animator>();        
    }

    public void Interact()
    {

        animator.SetTrigger("OpenDoor");
        this.gameObject.layer = 0;
    }

}
