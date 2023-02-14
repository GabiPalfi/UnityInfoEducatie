using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRoomScript : MonoBehaviour
{
    public GameObject room;
    public GameObject enemyCount;
    public GameObject trigger;
    public int child;
    public int enemyNumber;
    public GameObject loot;
    public GameObject interior;
    // Start is called before the first frame update
    void Start()
    {
        child = enemyCount.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log(child);
        if(enemyCount.transform.childCount==0){
           interior.SetActive(false);
           trigger.SetActive(false);
           loot.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            room.SetActive(true);
            //trigger.SetActive(false);
        }
       
    }
}
