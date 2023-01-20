using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float life;
    public GameObject effect;
    CircleCollider2D col;
    Rigidbody2D rb;
    public Vector2 direction;
    public Platformer thePlayer;
    public float directionX;
    public float directionY;
    

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(directionX*thePlayer.direction*2,directionY);
    }
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        thePlayer = FindObjectOfType<Platformer>();
        rb.AddForce(direction*speed);
        //StartCoroutine(Cooldown());


    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" || other.tag =="Ochi" || other.tag =="WallD"){
            Destroy(gameObject,0);
        }else{
            Destroy(gameObject,life);
            StartCoroutine(Cooldown());
        }
       
       
    }
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(life-0.1f);
        Instantiate(effect,transform.position,Quaternion.identity);
    }
}
