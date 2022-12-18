using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxx : MonoBehaviour
{
    private float lenght;
    private float startposx;
    private float startposy;
    public GameObject cam;
    public float paralaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startposx = transform.position.x;
        startposy = transform.position.y;

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // float temp = (cam.transform.position.x *(1-paralaxEffect));
        float dist = (cam.transform.position.x * paralaxEffect);
        transform.position = new Vector3(startposx + dist, transform.position.y,transform.position.z);

        // if(temp> startpos + lenght ){
        //     startpos += lenght;
        // }else{
        //     if(temp< startpos + lenght){
        //         startpos -= lenght;
        //     }
        // }
    }
}
