using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrute : MonoBehaviour
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
    private Vector2 effctPos;
    public GameObject smash;
    public Transform smashPos;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioClip die;

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
        effctPos = new Vector2(transform.position.x,transform.position.y+2);
        if(Health<=0){
            Instantiate(deathEffect,effctPos,Quaternion.identity);
            SoundManager.Instance.PlaySound(die);
            Destroy(this.gameObject);
            Counter.enemyKilled+=1;
        }
        disToPlayer = Vector2.Distance(transform.position,playerPos.position);

        if(disToPlayer < range && disToPlayer>minRange){
            ChasePlayer();
            anim.SetBool("IsWalking", true);
        }else
        {
            StopChasing();
            anim.SetBool("IsWalking", false);
        }
        Attack();

        
       
    }
    void Attack(){
        if(disToPlayer <= minRange && canAttack){
            isAttacking = true;
            minRange = 100;
        }
        if(isAttacking){
            canAttack = false;
            anim.SetBool("IsAttacking", true);
            StartCoroutine(Wait());
            minRange = 3;
        }
            
            
    }
    private IEnumerator Wait(){
        isAttacking = false;
        yield return new WaitForSeconds(1f);
        Instantiate(smash,smashPos.position,Quaternion.identity);
        cam.isShaking=true;
        anim.SetBool("IsAttacking", false);
        canAttack = true;

    }


    void ChasePlayer(){
        if(transform.position.x <playerPos.position.x){
            rb.velocity = new Vector2(speed,0);
            transform.localScale = new Vector2(-1,1);
        }else{
            rb.velocity = new Vector2(-speed,0);
            transform.localScale = new Vector2(1,1);
        }

    }


    void StopChasing(){
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            StartCoroutine(Cooldown());
            Health-=player.playerDamage;
            cam.isShaking=true;
            transform.position = new Vector2(transform.position.x+knockback*player.direction,transform.position.y);
            Instantiate(blood,effctPos,Quaternion.identity);
            player.transform.position = new Vector2(player.transform.position.x+playerKnockback*-player.direction,player.transform.position.y); 
        }
        if(other.tag == "Ball"){
            Health=0;
            cam.isShaking=true;
            Instantiate(deathEffect,effctPos,Quaternion.identity);
        }
    }
    private IEnumerator Cooldown(){
        yield return new WaitForSeconds(0.1f);
        hit.Play();
    }
}
