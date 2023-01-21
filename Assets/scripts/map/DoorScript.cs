using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Platformer thePlayer;
    public float lifeTime;
    public GameObject key;
    public GameObject effect;
    public GameObject camera;
    CameraScript cam;
    [SerializeField] private AudioClip Seffect;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Platformer>();
        cam = camera.GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name == "Player"){
            if(thePlayer.followingKey != null){
                thePlayer.followingKey.target = transform;
                SoundManager.Instance.PlaySound(Seffect);
                Destroy(gameObject,lifeTime);
                Destroy(key,lifeTime);
                StartCoroutine(Delay());
            }
        }
    }
    IEnumerator Delay(){
        yield return new WaitForSeconds(1.5f);
        Instantiate(effect,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        cam.isShaking = true;
    }
}
