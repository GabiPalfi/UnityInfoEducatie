using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss3 : MonoBehaviour
{
    [Header("Viata")]
    public int health;
    public int maxHealth;
    public bool hadDied;

    [Header("Referinte")]
    private Animator anim;
    CameraScript cam;
    public Platformer player;

    [Header("Damage")]
    public int damage;
    public bool canTakeDamage;
    public float timeBtwDamage;

    [Header("Game Objects")]
    public Slider healthBar;
    public GameObject camera;
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public GameObject canAttackIcon;
    public Transform effectPos;
    public GameObject fireBall;
    public GameObject loot;

    [Header("Audio")]
    [SerializeField] private AudioClip hit;
    
    [Header("Effects")]
    public GameObject blood;
    public GameObject dieEffect;

    [Header("Standard")]
    public float speed;
    public bool canMove;
    public bool is1active = true;
    public bool Stage2;
    public float minY;
    public float maxY;
    public int fireNumber;
    public float randY;
    public Vector2 firePos;
    public bool canShoot;
    public float cooldown;


    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Platformer>();
        health=maxHealth;
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
        if(canMove){
            if(is1active){
                transform.position = Vector2.MoveTowards(transform.position,patrolPoint1.position,speed*Time.deltaTime);
            }else
                transform.position = Vector2.MoveTowards(transform.position,patrolPoint2.position,speed*Time.deltaTime);
        
        
            if(Vector2.Distance(transform.position,patrolPoint1.position)<0.2f){
                transform.localScale = new Vector2(1f,1f);
                is1active = false;
            }
            if(Vector2.Distance(transform.position,patrolPoint2.position)<0.2f){
                transform.localScale = new Vector2(-1f,1f);
                is1active = true;
            }
        }
        if(health<=0){
            loot.SetActive(true);
            Instantiate(dieEffect,effectPos.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if(health<=maxHealth/2){
            Stage2=true;
            if(canShoot){
                Stage2Started();
                canShoot= false;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            if(canTakeDamage){
                anim.SetBool("Damage", true);
                StartCoroutine(Hurt());
                health-=player.playerDamage;
                canTakeDamage=false;
                Instantiate(blood,effectPos.position,Quaternion.identity);
                SoundManager.Instance.PlaySound(hit);

            }
        }
    }
    IEnumerator Hurt(){
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Damage", false);
        anim.SetBool("IsIdle", true);
        yield return new WaitForSeconds(0.5f);
        canTakeDamage=true;
    }
    public void Stage2Started(){
        for(int i=1;i<=fireNumber;i++){
            randY= Random.Range(minY,maxY);
            firePos = new Vector2(20,randY);
            Quaternion rot =  Quaternion.Euler(0,0,-90);
            Instantiate(fireBall,firePos,rot);
        }
        StartCoroutine(Wait());
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
