using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBoss : MonoBehaviour
{
    public GameObject bifa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter.isLibocaKilled){
            bifa.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="katana"){
            if(Counter.isLibocaKilled==false){
                SceneManager.LoadScene("BossArena1");
            }
            
        }
    }
}
