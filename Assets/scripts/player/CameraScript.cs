using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float aheadDistance;
    public float lookAhead;
    public float cameraSpeed;
    public float minimumY;
    public float endY;
    private float playerY;
    private bool isGrounded;
    private Vector2 wPos;
    private Vector2 wInitialPos;
    public float Up;
    public bool isShaking;
    public float duration = 1;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerY = player.position.y;
        wPos = new Vector2 (transform.position.x,transform.position.y + Up);
        // wInitialPos = new Vector2(transform.position.x, transform.position.y);
        if(playerY<minimumY || playerY >= endY){
            transform.position = new Vector3(player.position.x + lookAhead,transform.position.y,transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead,(aheadDistance*player.localScale.x),Time.deltaTime*cameraSpeed);
        }else{
            transform.position = new Vector3(player.position.x + lookAhead,player.position.y,transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead,(aheadDistance*player.localScale.x),Time.deltaTime*cameraSpeed);
        }
        if(isShaking){
            isShaking=false;
            StartCoroutine(Shake());
        }
        
    }
    private IEnumerator Shake(){
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            startPos = transform.position;
            transform.position = startPos + Random.insideUnitSphere * strenght;
            
            yield return null;
        }
        transform.position = startPos;
        transform.position = new Vector3(transform.position.x,7.86f,transform.position.z);
    }
}

