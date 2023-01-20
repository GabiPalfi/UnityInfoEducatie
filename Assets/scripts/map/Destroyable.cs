using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public GameObject effect;
    public GameObject camera;
    CameraScript cam;
    [SerializeField] private AudioClip Seffect;
    // Start is called before the first frame update
    void Start()
    {
        cam = camera.GetComponent<CameraScript>();
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            cam.isShaking=true;
            SoundManager.Instance.PlaySound(Seffect);
            Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
