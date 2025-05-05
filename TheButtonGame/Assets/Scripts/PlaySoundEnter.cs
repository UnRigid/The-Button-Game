using UnityEngine;

public class PlaySoundEnter : StateMachineBehaviour
{
    [SerializeField]private SoundType sound;
    [SerializeField, Range(0f,1f)]private float volume=1;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(sound , volume);
        
    }

    
}
