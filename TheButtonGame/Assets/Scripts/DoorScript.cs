using UnityEngine;

public class DoorScript : MonoBehaviour , IInteraction
{

    private Animator animator;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Corridor").GetComponent<Animator>();        
    }

    public void Interact()
    {

        animator.SetTrigger("OpenDoor"+transform.name);
        this.gameObject.layer = 0;
    }

}
