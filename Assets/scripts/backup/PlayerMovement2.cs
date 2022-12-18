using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 300;
    private Rigidbody2D body;
    private CapsuleCollider2D boxCollider;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private float wallJumpCooldown;
    public float dashSpeed;
    private float direction;
    private float scale;
    public bool isDashReady = true;
    public GameObject effect1;
    public GameObject effect2;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
  

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed*0.9f,body.velocity.y);

        if(horizontalInput > 0.01f){
            direction = 0.5f;
            transform.localScale = new Vector3(direction,0.5f,1);
        }else{
            if(horizontalInput < -0.01f){
                direction = -0.5f;
                transform.localScale = new Vector3(direction,0.5f,1);
            }
        }
        if(Input.GetKey(KeyCode.F) && isDashReady || Input.GetKey(KeyCode.F) && isDashReady){
            StartCoroutine(ShortDelay());
            // body.velocity = new Vector2(body.velocity.x + dashSpeed * direction,0f);
            body.position = new Vector2(transform.position.x + dashSpeed*direction,transform.position.y);
            StartCoroutine(Dash());
            StartCoroutine(Particle());   
        }else{
            body.velocity = new Vector2(horizontalInput*speed*0.9f,body.velocity.y);
        }
        if(Input.GetKey(KeyCode.F)&& isDashReady){
            StartCoroutine(Dash());
        }
        if(Input.GetKey(KeyCode.C)){
            scale = 0.25f;
            transform.localScale =  new Vector3(direction,scale,1);
            
        }
        
        if(Input.GetKey(KeyCode.Space) && isGrounded == true){
            Jump();
        }
        // isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);
        

    }
    private void Jump(){
       body.velocity = new Vector2(body.velocity.x , jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name == "enemy test" ){
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(collision.collider.tag == "Ground"){
            isGrounded = true;
        }else{
            isGrounded = false;
        }
        
    }
    // private bool isGrounded(){
    //     RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
    //     return raycastHit.collider != null;
    // }
    // private bool onWall(){
    //     RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,new Vector2(transform.localScale.x, 0),0.1f,wallLayer);
    //     return raycastHit.collider != null;
    // }
    IEnumerator Dash(){
        isDashReady = false;
        yield return new WaitForSeconds(3f);
        isDashReady = true;
    }
    IEnumerator Particle(){
        yield return new WaitForSeconds(0);
        Instantiate(effect1,transform.position,Quaternion.identity);
        Instantiate(effect2,transform.position,Quaternion.identity);
    }
    IEnumerator ShortDelay(){
        yield return new WaitForSeconds(0.1f);
    }

}
