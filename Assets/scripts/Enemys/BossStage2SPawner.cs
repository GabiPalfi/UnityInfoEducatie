using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage2SPawner : MonoBehaviour
{
    public GameObject rock;
    public GameObject semnDeExclamare;
    public float maxX;
    public float minX;
    public float conY;
    public float minY; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Spawn(){
        float x = Random.Range(minX,maxX);
        float y = conY;
        Instantiate(semnDeExclamare,transform.position+new Vector3(x,minY,0),transform.rotation);
        StartCoroutine(Wait());
        Instantiate(rock,transform.position+new Vector3(x,y,0),transform.rotation);
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1f);
        
    }
}
