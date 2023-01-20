using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private Animator anim;
    public bool isTrigger;
    public Platformer thePlayer;
   
    void Start(){
        anim = GetComponent<Animator>();
        thePlayer = FindObjectOfType<Platformer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
           isTrigger=true;
           anim.SetBool("IsActive", true);
           thePlayer.speed =0;
           thePlayer.direction =0;
           //thePlayer.canMove =false;
           //thePlayer.rb.velocity=0;
        }
    }
}
