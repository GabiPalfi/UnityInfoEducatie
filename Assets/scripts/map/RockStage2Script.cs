using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStage2Script : MonoBehaviour
{
    public float timeBtwDamage;
    public bool canTakeDamage;
    Platformer player;
    public int damage;
    public GameObject effect;
    [SerializeField] private AudioClip smashAudio; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Platformer>();
        damage = 1;
        timeBtwDamage =1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwDamage > 0){
            timeBtwDamage -= Time.deltaTime;
            canTakeDamage=false;
        }
    }
     private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name == "Floor" ){
            Destroy(gameObject,0.2f);
            Instantiate(effect,transform.position,Quaternion.identity);
            SoundManager.Instance.PlaySound(smashAudio);

        }
        if(collision.collider.name == "Player" ){
            if(timeBtwDamage <=0){
                player.currentHealth -= damage;
                player.healthBar.SetHealth(player.currentHealth);
                Debug.Log("am lovit");
                SoundManager.Instance.PlaySound(smashAudio);
            }
            
        }
    }
}
