using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCheckIn2 : MonoBehaviour
{
    public bool isTrigger;
    //public bool hasBeenTriggered=false;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
           isTrigger=true;
        }
    }
}
