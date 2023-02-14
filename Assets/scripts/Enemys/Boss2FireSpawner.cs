using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2FireSpawner : MonoBehaviour
{
    public GameObject fire;
    public GameObject effect;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(){
        Instantiate(effect,transform.position,transform.rotation);
        Instantiate(fire,transform.position,transform.rotation);
    }
}
