﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
     public float speed;
    public float finalPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed,transform.position.y,transform.position.z);
        if(transform.position.x <= -finalPos){
            transform.position = new Vector3(13,-1.65f,0);
        }
    }
}
