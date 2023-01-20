using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Variables")]
    public float Health;
    public float playerKnockback;
    public float knockback;
    public float speed;

    [Header("GameObjects")]
    public GameObject blood;
    public GameObject camera;
    CameraScript cam;
    public Platformer player;
    public GameObject deathEffect;
    [SerializeField] private AudioSource hit;

    [Header("Patrol")]
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public bool is1active = true;
    
    void Start()
    {
        cam = camera.GetComponent<CameraScript>();
        player = player.GetComponent<Platformer>();
    }

    void Update()
    {
        if(Health<=0){
            Instantiate(deathEffect,transform.position,Quaternion.identity);
            hit.Play();
            StartCoroutine(Cooldown());
            Destroy(this.gameObject);
            Counter.enemyKilled +=1;
        }
        if(is1active){
            transform.position = Vector2.MoveTowards(transform.position,patrolPoint1.position,speed*Time.deltaTime);
        }else
            transform.position = Vector2.MoveTowards(transform.position,patrolPoint2.position,speed*Time.deltaTime);
        
        
        if(Vector2.Distance(transform.position,patrolPoint1.position)<0.2f){
            transform.localScale = new Vector2(-0.17f,0.17f);
            is1active = false;
        }
        if(Vector2.Distance(transform.position,patrolPoint2.position)<0.2f){
            transform.localScale = new Vector2(0.17f,0.17f);
            is1active = true;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            StartCoroutine(Cooldown());
            Health-=player.playerDamage;
            cam.isShaking=true;
            transform.position = new Vector2(transform.position.x+knockback*player.direction,transform.position.y);
            Instantiate(blood,transform.position,Quaternion.identity);
            player.transform.position = new Vector2(player.transform.position.x+playerKnockback*-player.direction,player.transform.position.y); 
        }
    }
    private IEnumerator Cooldown(){
        yield return new WaitForSeconds(0.1f);
        hit.Play();
    }
}
