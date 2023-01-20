using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platformer : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement")]
    public bool canMove=true;
    public float speed;
    public float scale;
    public float direction;
    public float c_y;
    public float c_x;
    public float x;
    public float stunDuration;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public bool receveHealth;

    [Header("Damage")]
    public int playerDamage;
    public int CrabDamage;
    public int SpikeDamage;
    public int HamerDamage;
    public int TankDamage;
    public int knockback;
    public int plantHealth;
    public Transform resetPos;
    public Transform resetPos2;
    public int waterDamage;
    public int FishDamage;
    public int ochiDamage;
    public int axeObstacleDamage;
    
    [Header("Jumping")]
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public LayerMask groundLayer;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    [Header("Cheker")]
    public Transform isGroundedChecker;
    public bool isGrounded = false;
    public bool isDashReady = true;
    public bool isWalking;
    public float checkGroundRadius;

    [Header("Dash")]
    public float dashTime;
    public float dashcooldown;
    public float dashSpeed;
    public bool canDash;

    [Header("Katana")]
    public GameObject katana;
    Katana kat;
    
    [Header("Effects")]
    public GameObject effect1;
    public GameObject effect2;
    public GameObject groundPraticle;
    public GameObject jumpParticle;
    public GameObject dashEffect;
    public GameObject dashEffect1;

    [Header("PowerUps")]
    public float endPos;
    public Transform keyFollowPoint;
    public Key followingKey;
    public GameObject powerUpDoubleJump;
    public GameObject powerUpDash;

    [Header("Sound")]
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource walk;
   
    [Header("Camera")]
    public GameObject camera;
    CameraScript cam;

    [Header("Animation")]
    private Animator anim;
    public bool canAnimate;

    [Header("Mobile")]
    public Joystick joyStick;
    public bool hasBeenPresed;
    public bool jumpPresed;
    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        additionalJumps = defaultAdditionalJumps;
        endPos = GameObject.Find("Main Camera").GetComponent<CameraScript>().endY;
        kat = katana.GetComponent<Katana>();
        cam = camera.GetComponent<CameraScript>();
        canAnimate=true;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
        Ciupic();
        WalkingChecker();
        Katana();
        Dash();
        Health();

    }


    void Move() {
        if(canMove){
            float x = Input.GetAxisRaw("Horizontal");
            // float x = joyStick.Horizontal;
            // if(joyStick.Horizontal>=0.2f){
            //     x = 1;
            // }else if(joyStick.Horizontal <= -0.2f){
            //     x=-1;
            // }else{
            //     x=0;
            // }
            float moveBy = x * speed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
            
            if(x > 0.01f){
                direction = c_x;
                transform.localScale = new Vector3(direction,c_y,1);
            }else{
                if(x < -0.01f){
                    direction = -c_x;
                    transform.localScale = new Vector3(direction,c_y,1);
                }
            }
            if(canAnimate){
                if(x == 0){
                anim.SetBool("IsRunning", false);
            }else
                anim.SetBool("IsRunning", true);
                //walk.Play();
            }
            if(rb.velocity.x != 0 && isGrounded==true){
                if(!walk.isPlaying){
                    walk.Play();
                }
            }else{
                walk.Stop();
            }
        }
    }
    void Jump() {
        if (jumpPresed && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)) {
            Instantiate(jumpParticle,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
            anim.SetTrigger("TakeOf");
            jump.Play();
        }
    }

    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    void CheckIfGrounded() {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null) {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
            anim.SetBool("IsJumping", false);
            jumpPresed = false;
        } else {
            if (isGrounded) {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
             anim.SetBool("IsJumping", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name == "Crab" ){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            currentHealth-=CrabDamage;
            Hurt();
            Stuned();
        }
        if(collision.collider.name == "Spike" ){
            currentHealth-=SpikeDamage;
            Hurt();

        }
        if(collision.collider.name == "Enemy" ){
            currentHealth-=HamerDamage;
            Hurt();
        }
        if(collision.collider.name == "Corn" ){
            cam.isShaking = true;
            currentHealth-=TankDamage;
            healthBar.SetHealth(currentHealth);
            transform.position = new Vector2(transform.position.x +knockback*-direction,transform.position.y+knockback/2);
        }
        
        if(collision.collider.name == "double jump"){
            defaultAdditionalJumps =1;
            cam.isShaking = true;
            Destroy(powerUpDoubleJump);
        }
        if(collision.collider.name == "Dash"){
            canDash=true;
            cam.isShaking = true;
            Destroy(powerUpDash);
        }
        if(collision.collider.name == "Water"){
            transform.position = resetPos.position;
            cam.isShaking = true;
            currentHealth -= waterDamage;
            healthBar.SetHealth(currentHealth);
        }
        if(collision.collider.name == "Water1"){
            transform.position = resetPos2.position;
            cam.isShaking = true;
            currentHealth -= waterDamage;
            healthBar.SetHealth(currentHealth);
        }
        if(collision.collider.name == "Fish"){
            cam.isShaking = true;
            currentHealth -= FishDamage;
            healthBar.SetHealth(currentHealth);
        }
        if(collision.collider.name == "Ochi"){
            cam.isShaking = true;
            currentHealth -= ochiDamage;
            healthBar.SetHealth(currentHealth);
        }
        if(collision.collider.name == "Axe Obstacle"){
            cam.isShaking = true;
            currentHealth -= axeObstacleDamage;
            healthBar.SetHealth(currentHealth);
        }
        
        
        
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.tag == "Ochi"){
    //         cam.isShaking = true;
    //         currentHealth -= ochiDamage;
    //         healthBar.SetHealth(currentHealth);
    //     }
    // }

    private void Ciupic(){
        if(Input.GetKey(KeyCode.S) && isWalking){
            scale = 0.25f;
            transform.localScale =  new Vector3(direction,scale,1);
            
        }
    }
    void Hurt(){
        cam.isShaking = true;
        healthBar.SetHealth(currentHealth);
        transform.position = new Vector2(transform.position.x +3*-direction,transform.position.y);
    }
    void Stuned(){
        canMove=false;
        StartCoroutine(Stun());
    }
    void WalkingChecker(){
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)){
            isWalking = true;
        }
    }
    void Katana(){
        if(kat.weaponOwned){
            katana.transform.SetParent(this.transform);
        }else
            katana.transform.SetParent(null);
        
    }
    void Health(){
        if(currentHealth <=0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(receveHealth){
            healthBar.SetHealth(currentHealth);
            receveHealth = false;
        }
    }
    void Dash(){
        if(canDash){
            if(isDashReady && hasBeenPresed){
                rb.velocity = Vector2.left *dashSpeed*-direction;
                StartCoroutine(DashCooldown());
                Instantiate(dashEffect,transform.position,Quaternion.identity);
                Instantiate(dashEffect1,transform.position,Quaternion.identity);
                //isDashReady = false;
                anim.SetBool("IsDashing", true);
            }     
        }
        
                
    }
    public void HasBeenPresed(){
        hasBeenPresed = true;
    }
    public void JumpPresed(){
        jumpPresed = true;
    }
    // void Dash(){
    //     if(Input.GetKey(KeyCode.K) && isDashReady){
    //         rb.velocity = Vector2.left *dashSpeed*-direction;
    //         StartCoroutine(DashCooldown());
    //         Instantiate(dashEffect,transform.position,Quaternion.identity);
    //         Instantiate(dashEffect1,transform.position,Quaternion.identity);
    //         //isDashReady = false;
    //         anim.SetBool("IsDashing", true);
            
    //     }
    // }
    private IEnumerator DashCooldown(){
        yield return new WaitForSeconds(dashTime);
        isDashReady = false;
        hasBeenPresed = false;
        anim.SetBool("IsDashing", false);
        yield return new WaitForSeconds(dashcooldown);
        isDashReady = true;

    }
    private IEnumerator Stun(){
        yield return new WaitForSeconds(stunDuration);
        canMove=true;
    }
}
