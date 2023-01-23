using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScriptLiboca : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float timeBtwDamage;
    public Slider healthBar;
    public Platformer player;
    public int damage;
    public bool canTakeDamage;
    private Animator anim;
    public bool canMove;
    public Transform playerPos;
    public float speed;
    Rigidbody2D rb;
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public bool is1active = true;
    public bool hadDied;
    public bool hasStageTwoStarted;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioClip die;
    [SerializeField] private AudioClip hammer; 
    CameraScript cam;
    public GameObject camera;

    void Start()
    {
        health=maxHealth;
        cam = camera.GetComponent<CameraScript>();
        player = player.GetComponent<Platformer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwDamage > 0){
            timeBtwDamage -= Time.deltaTime;
        }
        healthBar.value =health;
        if(canMove){
            if(is1active){
                transform.position = Vector2.MoveTowards(transform.position,patrolPoint1.position,speed*Time.deltaTime);
            }else
                transform.position = Vector2.MoveTowards(transform.position,patrolPoint2.position,speed*Time.deltaTime);
        
        
            if(Vector2.Distance(transform.position,patrolPoint1.position)<0.2f){
                transform.localScale = new Vector2(-1f,1f);
                is1active = false;
            }
            if(Vector2.Distance(transform.position,patrolPoint2.position)<0.2f){
                transform.localScale = new Vector2(1f,1f);
                is1active = true;
            }
        }
        if(health<=0){
            if(hadDied == false){
                anim.SetBool("HasDied",true);
                SoundManager.Instance.PlaySound(die);
                hadDied=true;
            }
            
        }
        if(health<=maxHealth/2){
            hasStageTwoStarted = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(timeBtwDamage <=0){
                if(canMove){
                    player.currentHealth -= damage*2;
                    player.healthBar.SetHealth(player.currentHealth);
                }else{
                    player.currentHealth -= damage;
                    player.healthBar.SetHealth(player.currentHealth);
                }
               
            }
        }
        if(other.tag =="katana"){
            if(canTakeDamage){
                anim.SetBool("IsDamaged", true);
                hit.Play();
                StartCoroutine(Hurt());
                health-=player.playerDamage;
                canTakeDamage=false;
                

            }
           
        }
    }
    IEnumerator Hurt(){
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsDamaged", false);
        canTakeDamage=true;
    }
    // void ChasePlayer(){
    //     if(transform.position.x <playerPos.position.x){
    //         rb.velocity = new Vector2(speed,0);
    //         transform.localScale = new Vector2(1,1);
    //     }else{
    //         rb.velocity = new Vector2(-speed,0);
    //         transform.localScale = new Vector2(-1,1);
    //     }

    // }
    public void IsHittingGround(){
        cam.isShaking=true;
    }
}
