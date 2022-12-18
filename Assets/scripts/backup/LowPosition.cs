using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Low();
    }
    void Low(){
         if(Input.GetKey(KeyCode.Space)){
            transform.position = new Vector2(transform.position.x,transform.position.y-2);
        }
    }
}
