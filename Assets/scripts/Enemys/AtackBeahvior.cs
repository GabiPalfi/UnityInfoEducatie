using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackBeahvior : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    Boss3 bossScript;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript = GameObject.Find("Boss Battle").GetComponent<Boss3>();
        animator.SetBool("IsIdle",true);
        timer = Random.Range(minTime,maxTime);
        //bossScript.canAttackIcon.SetActive(false);
        //bossScript.canTakeDamage = false;
        bossScript.canMove = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(timer <=0){
            animator.SetTrigger("Idle");
        }else{
            timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript.canTakeDamage = true;
        bossScript.canMove = false;

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
