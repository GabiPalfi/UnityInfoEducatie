using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float life;
    public GameObject effect;
    private Platformer thePlayer;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed,transform.position.y,transform.position.z);
    }
     private void Start() {
        thePlayer = FindObjectOfType<Platformer>();
        Invoke("Destroy",life);

    }
    void Destroy(){
        Instantiate(effect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
