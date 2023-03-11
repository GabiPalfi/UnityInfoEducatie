using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToBoss3 : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="katana"){
            SceneManager.LoadScene("BossArena3");
            
        }
    }
}
