using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float speed;
    public Transform trigger;
    public float endPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = trigger.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+speed,transform.position.y,transform.position.z);
        if(transform.position.x > endPos){
            transform.position = trigger.position;
        }
    }
}
