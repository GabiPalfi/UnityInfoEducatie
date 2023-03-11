using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Stage2 : MonoBehaviour
{
    public int direction;
    public float speed;
    public float duration;
    public Platformer player;
    CircleCollider2D col;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Puff());
        player = GameObject.Find("Player").GetComponent<Platformer>();
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2((transform.position.x+speed)*direction,transform.position.y);
    }
    IEnumerator Puff(){
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            player.currentHealth-=2;
            player.healthBar.SetHealth(player.currentHealth);
            Instantiate(effect,transform.position,Quaternion.identity);
            col.enabled=!col.enabled;
        }
    }
}
