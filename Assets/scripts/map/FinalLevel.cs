using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            StartCoroutine(Wait());
            
        }
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("FinalLevel");
    }

}
