using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesteAnim : MonoBehaviour
{
    private Animator anim;
     public GameObject effect;
    //public PesteAnimCheck trigger;
    void Start()
    {
        anim = GetComponent<Animator>();
        //trigger = FindObjectOfType<PesteAnimCheck>();
    }

    // void Update(){
    //     if(trigger.isTrigger){
    //         anim.SetBool("IsActive",true);
    //         Debug.Log("alit");
    //     }
    // }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
          anim.SetBool("IsActive",true);
          Debug.Log("alit");
        }
        if(other.tag == "katana"){
            Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
