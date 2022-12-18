using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
     [Header("Variables")]
    public float Health;
    public float playerKnockback;
    public float knockback;
    public float speed;
    public float range;
    public float minRange;
    public bool isAttacking;
    public bool canAttack = true;
    public float direct;
    public float offset;

    [Header("GameObjects")]
    public GameObject blood;
    public GameObject camera;
    CameraScript cam;
    public Platformer player;
    public GameObject deathEffect;
    public Transform playerPos;
    Rigidbody2D rb;
    private Animator anim;
    private float disToPlayer;
    public Transform effctPos;
    private Vector2 endPoint;

    // [Header("Patrol")]
    // public Transform patrolPoint1;
    // public Transform patrolPoint2;
    // public bool is1active = true;
    
    void Start()
    {
        cam = camera.GetComponent<CameraScript>();
        player = player.GetComponent<Platformer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Health<=0){
            Instantiate(deathEffect,effctPos.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
        disToPlayer = Vector2.Distance(transform.position,playerPos.position);

        if(disToPlayer < range && canAttack){
            Attack();
            Wait();
            isAttacking = true;
            anim.SetBool("IsRunning",true);
        }else{
            StopChasing();
            Wait();
            anim.SetBool("IsRunning",false);
            isAttacking = false;
        }
        
    }
    void Attack(){
        if(transform.position.x <playerPos.position.x + offset*direct){
            rb.velocity = new Vector2(speed,0);
            transform.localScale = new Vector2(-1,1);
            direct = 1;

        }else{
            rb.velocity = new Vector2(-speed,0);
            transform.localScale = new Vector2(1,1);
            direct = -1;
        }
       

    }
    void StopChasing(){
        rb.velocity = Vector2.zero;
    }
            

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            StartCoroutine(Cooldown());
            Health-=50;
            cam.isShaking=true;
            transform.position = new Vector2(transform.position.x+knockback*player.direction,transform.position.y);
            Instantiate(blood,effctPos.position,Quaternion.identity);
            player.transform.position = new Vector2(player.transform.position.x+playerKnockback*-player.direction,player.transform.position.y); 
        }
    }
    private IEnumerator Cooldown(){
        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator Wait(){
        yield return new WaitForSeconds(1f);
    }
}
