using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonSelect : MonoBehaviour
{
    public GameObject v1,v2,v3,v4,v5,v6;
    // Start is called before the first frame update
    void Start()
    {
        if(Counter.levelRL==1){
            V6();
        }else{
            if(Counter.levelRL==5){
                V5();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void V1(){

    }
    public void V2(){

    }
    public void V3(){
        
    }
    public void V4(){
        
    }
    public void V5(){
        
    }
    public void V6(){
        v6.SetActive(true);
    }
}
