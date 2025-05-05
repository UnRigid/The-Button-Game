using UnityEngine;
using System;
public class ExitBroadcast : StateMachineBehaviour
{
    
    public static event Action NextLevel;


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NextLevel?.Invoke();
    }

    
}
