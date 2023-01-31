using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSTage2BossBattle : MonoBehaviour
{
    public Platformer player;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Platformer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            player.currentHealth-=damage;
            player.healthBar.SetHealth(player.currentHealth);
        }
    }
}
