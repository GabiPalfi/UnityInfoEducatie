using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private Animator anim;
    CircleCollider2D col;
    public GameObject efect;
    public bool canAttack;
    public float attackColdown;
    public Transform target;
    public float speed;
    public bool weaponOwned;
    public bool gettingAttacked;
    public Platformer thePlayer;
    public UpgradeSistem upgrade;
    [SerializeField] private AudioSource slash;
    [SerializeField] private AudioClip pickUPsound;

   [Header("Sprites")]
   public Sprite katana2;
   public Sprite axe;
   public Sprite katana3;
   public Sprite axe2;
   public int attackCount=0;
    // public GameObject camera;
    // CameraScript cam;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        thePlayer = FindObjectOfType<Platformer>();
        upgrade= FindObjectOfType<UpgradeSistem>();
        
        // col.enabled = !col.enabled;
        // cam = camera.GetComponent<CameraScript>();

       
    }

    // Update is called once per frame
    void Update()
    {  
        
        if(Input.GetKey(KeyCode.L) && canAttack && weaponOwned){
            Attack();
        }
        if(weaponOwned){
            transform.position = Vector3.Lerp(transform.position,target.position,speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E) && weaponOwned){
            //StartCoroutine(PickUp());
            //weaponOwned = false;
            col.enabled = !col.enabled;
            
        }
        if(Input.GetKey(KeyCode.L)){
            col.radius = 10;
            col.offset = new Vector2(5.5f,10f);
        }
        if(attackCount==3){
            attackCount=1;
        }

    }
    public void Attack(){
        if(canAttack && weaponOwned){
            attackCount++;
            if(attackCount%2==1){
                anim.Play("katana",0,0.0f);
                //attackColdown-=0.25f;
            }else{
                anim.Play("katana 2",0,0.0f);
                //attackColdown-=0.25f;
            }
            Instantiate(efect,transform.position,Quaternion.identity);
            canAttack = false;
            col.enabled = !col.enabled;
            slash.Play();
            StartCoroutine(Coroutine());
        }
       
    }
    private IEnumerator Coroutine(){
        if(attackCount%2==0){
            attackColdown-=0.25f;
        }else{
            attackColdown=0.5f;
        }
        
        yield return new WaitForSeconds(attackColdown);
        //attackCount=0;
        canAttack = true;
        col.enabled = !col.enabled;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            SoundManager.Instance.PlaySound(pickUPsound);
            weaponOwned = true;
            col.enabled = !col.enabled;
        }
        if(other.tag == "Grass"){
            Counter.grassDestroyed +=1;
        }
        if(other.tag == "Rock"){
            Counter.rockDestroyed +=1;
        }
    }
    public void Katana2(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = katana2;
        attackColdown-=0.1f;
        thePlayer.playerDamage=140;
    }
    public void Axe(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = axe;
        attackColdown+=0.2f;
        thePlayer.playerDamage=190;
    }
    public void Katana3(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = katana3;
        attackColdown-=0.1f;
        thePlayer.playerDamage+=230;
    }
     public void Axe2(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = axe2;
        attackColdown+=0.2f;
        thePlayer.playerDamage=280;
    }
}
