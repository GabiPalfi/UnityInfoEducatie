using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossScriptMage : MonoBehaviour
{
    [Header("Viata")]
    public int health;
    public int maxHealth;
    public bool hadDied;

    [Header("Referinte")]
    private Animator anim;
    CameraScript cam;
    public Platformer player;
    public Boss2FireSpawner spawner;

    [Header("Damage")]
    public int damage;
    public bool canTakeDamage;
    public float timeBtwDamage;
    public bool isAttacking;
    public bool hasStageTwoStarted;
    public bool canAttack;
    public bool stage2Start;

    [Header("Sound")]
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioClip die;
    [SerializeField] private AudioClip hammer; 
    [SerializeField] private AudioClip fireStage2; 
    [SerializeField] private AudioSource fireAudio;


    [Header("Game Objects")]
    public Slider healthBar;
    public GameObject camera;
    public GameObject warning;
    public GameObject fire;
    public GameObject loot;

    [Header("Game Objects")]
    public float speed;
    public bool canMove;

    [Header("Other")]
    public float startTime;
    public bool finishAttack;
    public float cooldwon;

    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Platformer>();
        health=maxHealth;
        spawner = spawner.GetComponent<Boss2FireSpawner>();
        cam = camera.GetComponent<CameraScript>();
        anim = GetComponent<Animator>();
        canTakeDamage=true;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value =health;
        
        if(timeBtwDamage > 0){
            timeBtwDamage -= Time.deltaTime;
            //canTakeDamage=false;
        }
        if(isAttacking==false){
            StartCoroutine(WaitForStart());

            if(canAttack){
                StartAttacking();
                canTakeDamage=false;
            }
        } 
        if(health <= maxHealth/2){
            hasStageTwoStarted = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            if(canTakeDamage){
                anim.SetBool("TakeDamage", true);
                StartCoroutine(Hurt());
                health-=player.playerDamage;
                canTakeDamage=false;
            }
            if(health<=0){
                if(hadDied == false){
                anim.SetTrigger("HasDied");
                hadDied=true;
                anim.SetBool("IsIdle",false);
                anim.SetBool("TakeDamage",false);
                anim.SetBool("IsAtacking",false);
                Counter.isBoss2Killed=true;
                loot.SetActive(true);
                canTakeDamage=false;
                canAttack=false;
            }
            canTakeDamage = false;
            damage =0;
        }
        }
        if(other.tag == "Player"){
            if(timeBtwDamage <=0){
                if(canMove){
                    player.currentHealth -= damage*Counter.dificulty;
                    player.healthBar.SetHealth(player.currentHealth);
                }
            }
        }
    }
    IEnumerator Hurt(){
        yield return new WaitForSeconds(0.1f);
        if(isAttacking==false){
            canTakeDamage=true;
        }
        
        anim.SetBool("TakeDamage", false);
        hit.Play();
        
    }
    IEnumerator WaitForStart(){
        yield return new WaitForSeconds(startTime);
        canAttack=true;
    }
    public void Attack(){
        if(hasStageTwoStarted==false){
            fireAudio.Play();
            StartCoroutine(WaitForSound());
        }
        
    }
    IEnumerator WaitForSound(){
        yield return new WaitForSeconds(0.2f);
        spawner.Attack();
    }
    void StartAttacking(){
        canTakeDamage=false;
        anim.SetBool("IsAtacking",true);
        isAttacking=true;
        canMove=true;
        
    }
    public void StartStage2(){
        if(hasStageTwoStarted){
            if(stage2Start==false){
                SoundManager.Instance.PlaySound(fireStage2);
                stage2Start = true;
                warning.SetActive(true);
                StartCoroutine(WaitToStartStage2());
            }
        }
    }
    IEnumerator WaitToStartStage2(){
        yield return new WaitForSeconds(1);
        warning.SetActive(false);
        fire.SetActive(true);
        StartCoroutine(CloseFire());
    }
    IEnumerator CloseFire(){
        yield return new WaitForSeconds(1);
        fire.SetActive(false);
        stage2Start = false;
    }
    void FinishAttacking(){
        anim.SetBool("IsIdle",true);
        canAttack=false;
        anim.SetBool("IsAtacking",false);
        StartCoroutine(WaitToAttckAgain());
        // canAttack=false;
    }
    IEnumerator WaitToAttckAgain(){
        yield return new WaitForSeconds(cooldwon);
        //isAttacking=false;
        canTakeDamage=true;
        yield return new WaitForSeconds(cooldwon);
        isAttacking=false;
    }
}
