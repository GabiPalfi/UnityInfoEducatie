using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish2Script : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    private bool canFly;
    public int strenght;
    public float flyingTime;
    public FishCheckIn2 trigger;
    public Transform restPos;
    public GameObject effect;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trigger = FindObjectOfType<FishCheckIn2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.isTrigger){
            canFly=true;
            trigger.isTrigger=false;
        }
        if(canFly){
            rb.AddForce(direction*strenght);
            StartCoroutine(Timp());
        }
        
    }
    IEnumerator Timp(){
        yield return new WaitForSeconds(flyingTime);
        canFly=false;
        StartCoroutine(Die());
    }
     IEnumerator Die(){
        yield return new WaitForSeconds(1);
        Destroy(gameObject,0.5f);
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
