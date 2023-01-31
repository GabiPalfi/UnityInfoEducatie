using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBoss2 : MonoBehaviour
{
    public GameObject bifa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter.isBoss2Killed){
            bifa.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="katana"){
            if(Counter.isBoss2Killed==false){
                SceneManager.LoadScene("BossArena2");
            }
            
        }
    }
}
