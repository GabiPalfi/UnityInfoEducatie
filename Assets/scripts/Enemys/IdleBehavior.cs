using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    BossScriptLiboca bossScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript = GameObject.Find("BossBattle").GetComponent<BossScriptLiboca>();
        animator.SetBool("IsJumping",false);
        animator.SetBool("IsIdle",true);
        timer = Random.Range(minTime,maxTime);
        bossScript.canAttackIcon.SetActive(false);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <=0){
            animator.SetTrigger("Jump");
        }else{
            timer -= Time.deltaTime;
        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
