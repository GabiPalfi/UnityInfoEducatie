using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttackBehavior : StateMachineBehaviour
{
    BossScriptMage bossScript;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       bossScript = GameObject.Find("Boss battle").GetComponent<BossScriptMage>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       bossScript.finishAttack=true;
    }

    
}
