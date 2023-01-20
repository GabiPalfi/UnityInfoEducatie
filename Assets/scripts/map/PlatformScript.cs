using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformScript : MonoBehaviour
{
    private Animator anim;
    private LeverScript lever;
    // Start is called before the first frame update
    void Start()
    {
        lever = FindObjectOfType<LeverScript>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.isTrigger){
            anim.SetBool("IsActive", true);
        }
    }
}
