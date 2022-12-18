using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetwenShots;
    public float startTimeBetwenShots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetwenShots <= 0){
            if(Input.GetKey(KeyCode.F)){
            Instantiate(projectile,shotPoint.position,transform.rotation);
            timeBetwenShots = startTimeBetwenShots;
            }
        }else{
            timeBetwenShots -= Time.deltaTime;
        }
        
    }
}
