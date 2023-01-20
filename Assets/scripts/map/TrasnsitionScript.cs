using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasnsitionScript : MonoBehaviour
{
    public EndLevel end;
    public Animator transition;
    void Start()
    {
        end = FindObjectOfType<EndLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if(end.endLevel){
            LoadNextScene();
        }
    }
    public void LoadNextScene(){
        StartCoroutine(LoadLevel());

    }
    IEnumerator LoadLevel(){
        transition.SetTrigger("Active");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
