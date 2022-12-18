using System.Collections;
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
    // public GameObject camera;
    // CameraScript cam;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
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
    }
}
