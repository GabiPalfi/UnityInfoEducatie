﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public Transform posA,posB;
    public int Speed;
    Vector2 targetPos;
    public bool canBoatMove;
    public GameObject button;
    [SerializeField] private AudioClip waterSound;
    public bool canSound;
    public GameObject effectBoat;

    

    void Start()
    {
        targetPos=posB.position;
    }

   
    void Update()
    {
        if(canBoatMove){
            if(Vector2.Distance(transform.position,posA.position)<0.1f){
                targetPos=posB.position;
                transform.localScale = new Vector2(-1,1);
            }
            if(Vector2.Distance(transform.position,posB.position)<0.1f){
                targetPos=posA.position;
                transform.localScale = new Vector2(1,1);
            }
            transform.position = Vector2.MoveTowards(transform.position,targetPos,Speed*Time.deltaTime);
        }
        if(canSound){
            StartCoroutine(Sound());
            canSound=false;
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.transform.SetParent(this.transform);
            //button.SetActive(true);
            canBoatMove = true;
            
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            other.transform.SetParent(null);
            
        }
    }
     public void ButtonPressed(){
        button.SetActive(false);
        canBoatMove=true;
        canSound=true;
        effectBoat.SetActive(true);
    }
    IEnumerator Sound(){
        SoundManager.Instance.PlaySound(waterSound);
        yield return new WaitForSeconds(3.5f);
        canSound=true;
    }
}
