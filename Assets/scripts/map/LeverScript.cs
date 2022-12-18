using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private Animator anim;
    public bool isTrigger;
    private LeverScript lever;
    void Start(){
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
           isTrigger=true;
           anim.SetBool("IsActive", true);
            StartCoroutine(Wait());
        }
    }
    private IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
    }
}
