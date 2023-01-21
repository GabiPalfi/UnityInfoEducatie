using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;
    public float followSpeed;
    public Transform target;
    [SerializeField] private AudioClip Seffect;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing){
            transform.position = Vector3.Lerp(transform.position,target.position,followSpeed*Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name == "Player"){
            if(!isFollowing){
                SoundManager.Instance.PlaySound(Seffect);
               Platformer thePlayer = FindObjectOfType<Platformer>();
               target = thePlayer.keyFollowPoint;
               isFollowing = true;
               thePlayer.followingKey = this;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        
    }
}
