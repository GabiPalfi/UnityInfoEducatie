using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AttackCheck : MonoBehaviour
{
    public Platformer player;
    public int playerDamage;
    public GameObject effect;
    public Transform effectPos;
    [SerializeField] private AudioClip hit;
    public GameObject camera;
    CameraScript cam;
    CircleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Platformer>();
        cam = camera.GetComponent<CameraScript>();
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            player.currentHealth-=playerDamage*Counter.dificulty;
            player.healthBar.SetHealth(player.currentHealth);
            Instantiate(effect,effectPos.position,Quaternion.identity);
            SoundManager.Instance.PlaySound(hit);
            cam.isShaking=true;
            StartCoroutine(ColOf());
        }
    }
    IEnumerator ColOf(){
        col.enabled = !col.enabled;
        yield return new WaitForSeconds(0.3f);
        col.enabled = !col.enabled;
    }
}
