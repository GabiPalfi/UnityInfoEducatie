using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatGetIn : MonoBehaviour
{
    public GameObject button;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            button.SetActive(true);
        }
    }
    public void ButtonPressed(){
        button.SetActive(false);
    }
}
