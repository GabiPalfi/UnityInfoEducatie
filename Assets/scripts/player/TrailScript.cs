using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        trail=gameObject.GetComponent<TrailRenderer>();
        trail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            StartEffect();
           
        }
    }
    private IEnumerator Trail(){
        yield return new WaitForSeconds(0.45f);
        trail.enabled = false;
    }
    public void StartEffect(){
        trail.enabled = true;
        StartCoroutine(Trail());
    }
}
