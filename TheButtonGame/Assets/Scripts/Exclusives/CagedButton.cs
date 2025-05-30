using UnityEngine;

public class CagedButton : MonoBehaviour, IInteraction
{

    static CagedButton instance;
    static Animator animator;


    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        animator = GameObject.FindGameObjectWithTag("Button").GetComponent<Animator>();

        animator.SetBool("HasKey", false);
        animator.SetBool("CageIsOpen", false);

        KeyScript.PickUpKey += () =>
        {
            animator.SetBool("HasKey", true);
            Debug.Log("Picked Up Key");
        };
    }


    public void Interact()
    {
        if (animator.GetBool("HasKey"))
        {
            if (!animator.GetBool("CageIsOpen"))
            {
                animator.SetTrigger("OpenCage");
                animator.SetBool("CageIsOpen", true);
            }
            else
            {
                animator.SetTrigger("PressButton");
            }
        }
        
        
    }

    
}
