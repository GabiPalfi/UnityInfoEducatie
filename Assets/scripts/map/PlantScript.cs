using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    Platformer player;
    public GameObject pl;
    // Start is called before the first frame update
    void Start()
    {
        player = pl.GetComponent<Platformer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            if(player.currentHealth<player.maxHealth){
                player.currentHealth += player.plantHealth;
                if(player.currentHealth >=player.maxHealth){
                    player.currentHealth = player.maxHealth;
                }
                player.receveHealth = true;
            }
            
            
        }
    }
}
