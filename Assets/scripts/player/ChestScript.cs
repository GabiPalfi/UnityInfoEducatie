using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public Platformer thePlayer;
    public Sprite greenArmor;
    public Sprite redArmor;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Platformer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GreenArmor(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = greenArmor;
        thePlayer.speed=15.5f;
        thePlayer.maxHealth =25;
         thePlayer.currentHealth=thePlayer.maxHealth;
        thePlayer.healthBar.SetMaxHealth(thePlayer.maxHealth);
    }
    public void RedArmor(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = redArmor;
        thePlayer.maxHealth =30;
        thePlayer.speed=14.2f;
        thePlayer.currentHealth=thePlayer.maxHealth;
        thePlayer.healthBar.SetMaxHealth(thePlayer.maxHealth);
    }
}
