﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private Animator anim;
    CircleCollider2D col;
    public GameObject efect;
    public bool canAttack;
    public float attackColdown;
    public Transform target;
    public float speed;
    public bool weaponOwned;
    public bool gettingAttacked;
    public Platformer thePlayer;
    public UpgradeSistem upgrade;
    [SerializeField] private AudioSource slash;

   [Header("Sprites")]
   public Sprite katana2;
   public Sprite axe;
   public Sprite katana3;
   public Sprite axe2;
    // public GameObject camera;
    // CameraScript cam;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        thePlayer = FindObjectOfType<Platformer>();
        upgrade= FindObjectOfType<UpgradeSistem>();
        
        // col.enabled = !col.enabled;
        // cam = camera.GetComponent<CameraScript>();

       
    }

    // Update is called once per frame
    void Update()
    {  
        
        if(Input.GetKey(KeyCode.L) && canAttack && weaponOwned){
            Attack();
        }
        if(weaponOwned){
            transform.position = Vector3.Lerp(transform.position,target.position,speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E) && weaponOwned){
            //StartCoroutine(PickUp());
            //weaponOwned = false;
            col.enabled = !col.enabled;
            
        }
        if(Input.GetKey(KeyCode.L)){
            col.radius = 10;
            col.offset = new Vector2(5.5f,10f);
        }
        

    }
    public void Attack(){
        if(canAttack && weaponOwned){
            anim.Play("katana",0,0.0f);
            Instantiate(efect,transform.position,Quaternion.identity);
            canAttack = false;
            col.enabled = !col.enabled;
            slash.Play();
            StartCoroutine(Coroutine());
        }
       
    }
    private IEnumerator Coroutine(){
        yield return new WaitForSeconds(attackColdown);
        canAttack = true;
        col.enabled = !col.enabled;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            weaponOwned = true;
            col.enabled = !col.enabled;
        }
        if(other.tag == "Grass"){
            Counter.grassDestroyed +=1;
        }
        if(other.tag == "Rock"){
            Counter.rockDestroyed +=1;
        }
    }
    public void Katana2(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = katana2;
        attackColdown-=0.1f;
        thePlayer.playerDamage=70;
    }
    public void Axe(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = axe;
        attackColdown+=0.2f;
        thePlayer.playerDamage=90;
    }
    public void Katana3(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = katana3;
        attackColdown-=0.1f;
        thePlayer.playerDamage+=100;
    }
     public void Axe2(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = axe2;
        attackColdown+=0.2f;
        thePlayer.playerDamage=150;
    }
}
