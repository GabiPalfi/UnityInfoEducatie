using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyebleWall : MonoBehaviour
{
    public GameObject smoke;
     public GameObject smoke2;
    public GameObject brick;
    public GameObject wallDiff;
    public GameObject wallMain;
    [SerializeField] private AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            Instantiate(smoke,transform.position,Quaternion.identity);

        }
        if(other.tag == "Ball"){
            SoundManager.Instance.PlaySound(boom);
            Instantiate(brick,transform.position,Quaternion.identity);
            Instantiate(smoke2,transform.position,Quaternion.identity);
            wallDiff.SetActive(true);
            wallMain.SetActive(false);
        }
    }
}
