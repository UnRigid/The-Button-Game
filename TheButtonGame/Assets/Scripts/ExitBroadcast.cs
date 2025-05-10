using UnityEngine;
using System;
public class ExitBroadcast : StateMachineBehaviour
{
    
    public static event Action Pressed_Button;


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Pressed_Button?.Invoke();
    }

    
}
