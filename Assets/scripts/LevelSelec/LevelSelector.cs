using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    public int levelCount;
    public int minLevel;
    public GameObject selectMenu;
    public Platformer player;
    public int level;
    public static int lastLevel;
    public static bool shopAppeared;
    public int shopID=12;

    
    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Platformer>();
        level = Random.Range(minLevel,levelCount);
        if(level==lastLevel){
            level = Random.Range(minLevel,levelCount);
        }else{
            if(level==shopID && shopAppeared){
                level = Random.Range(minLevel,levelCount);
            }
        }
        Debug.Log(level);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 9){
            Counter.levelRL=0;
        }
        if(level == shopID){
            shopAppeared=true;
        }
            
    }
    public void SelectLevel(){
        // int level = Random.Range(minLevel,levelCount);
        // Debug.Log(level);
        if(Counter.levelRL == 5){
            SceneManager.LoadScene("BossArena1");
        }else{
            SceneManager.LoadScene(level);
            lastLevel = level;
            Counter.levelRL++;
            Debug.Log(Counter.levelRL);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "katana"){
            SelectMenu();
        }
    }
    public void SelectMenu(){
        selectMenu.SetActive(true);
        //player.canMove=false;
        player.speed =0;
        player.direction =0;
        //player.canAnimate = false;
    }
}
