using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public float speed;
    private Transform playerPos;
    BossScriptLiboca bossScript;
    Platformer player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript = GameObject.Find("BossBattle").GetComponent<BossScriptLiboca>();
        player = GameObject.Find("Player").GetComponent<Platformer>();
        //playerPos = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>();
        timer = Random.Range(minTime,maxTime);
        animator.SetBool("IsJumping",true);
        animator.SetBool("IsIdle",false);
        bossScript.canTakeDamage = false;
        bossScript.canMove = true;
        bossScript.canAttackIcon.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(timer <=0){
            animator.SetTrigger("Idle");
        }else{
            timer -= Time.deltaTime;
        }
        // Vector2 target = new Vector2(playerPos.position.x,animator.transform.position.y);
        // animator.transform.position = Vector2.MoveTowards(animator.transform.position, target,speed*Time.deltaTime );
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript.canTakeDamage = true;
        bossScript.canMove = false;
    }

    
}
