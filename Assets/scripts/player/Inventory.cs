using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject bombSlot;
    public GameObject eyeSlot;
    public GameObject bombButton;
    // Start is called before the first frame update
    void Start()
    {
        if(Counter.bombNumber>0){
            bombSlot.SetActive(true);
        }else{
            //bombButton.SetActive(false);
        }
        if(Counter.DeadEyeNumber>0){
            eyeSlot.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter.bombNumber<0){
            bombButton.SetActive(false);
        }
    }
}
