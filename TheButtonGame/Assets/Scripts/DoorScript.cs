using UnityEngine;

public class DoorScript : MonoBehaviour , IInteraction
{

    private Animator animator;
    
    private void Awake() {
        this.GetComponent<Animator>();
    }

    public void Interact()
    {
        Destroy(this.transform.gameObject.GetComponent<BoxCollider>());
        animator.SetTrigger("OpenDoor");
    }

}
