using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Stage2 : MonoBehaviour
{
    public int minX;
    public int maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stage2(){
        float x = Random.Range(minX,maxX);
        transform.position = new Vector2(x,transform.position.y);
    }
}
