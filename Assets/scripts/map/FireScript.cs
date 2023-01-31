using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float speed;
    //public Vector3 playerPos;
    public Vector2 Pos;
    public Vector2 FinalPos;
    Platformer player;
    public int damage;
    public float time;
    //[SerializeField] private AudioSource fireAudio;
    public GameObject effect;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Platformer>();
        // damage=1;
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        transform.up = (playerPos - transform.position)*-1;
        Pos=player.transform.position;
        FinalPos = new Vector2(player.transform.position.x,0);
        //fireAudio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,FinalPos,speed*Time.deltaTime);
        //transform.position = new Vector3(Pos.transform.rotation*Vector3.forward);
        StartCoroutine(Gone());
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name == "Floor" ){
            Destroy(gameObject,0.2f);
            Instantiate(effect,transform.position, Quaternion.identity);
            // Instantiate(effect,transform.position,Quaternion.identity);
            // SoundManager.Instance.PlaySound(smashAudio);

        }
        if(collision.collider.name == "Player" ){
            player.currentHealth -= damage;
            Instantiate(effect,transform.position, Quaternion.identity);
            player.healthBar.SetHealth(player.currentHealth);
            //SoundManager.Instance.PlaySound(smashAudio);
            Destroy(gameObject,0.2f);
            
        }
    }
    IEnumerator Gone(){
        yield return new WaitForSeconds(time);
        Destroy(gameObject,0.2f);
    }
}
