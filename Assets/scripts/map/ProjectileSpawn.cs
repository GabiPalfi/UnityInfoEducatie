using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject projectile;
    public int projectileCount;
    public Transform target;
    public bool canShoot;
    public float delay;
    public GameObject button;
    public int bombPlantRequiere;
    public int bombRockRequiere;
    public int deadEyeRequiere;
    public GameObject bombSlot;

    // Update is called once per frame
    void Update()
    {
        if(projectileCount>0){
            button.SetActive(true);
        }else{
            button.SetActive(false);
        }
        if(Counter.bombNumber>0){
            button.SetActive(true);
        }else{
            button.SetActive(false);
        }
        // if((Input.GetKey(KeyCode.H)&&projectileCount>0)&&canShoot){
        //     Instantiate(projectile,transform.position,transform.rotation);
        //     projectileCount--;
        //     canShoot=false;
        //     StartCoroutine(Wait());
        // }
    }
    public void Shoot(){
        if(projectileCount>0&&canShoot&&Counter.bombNumber>0){
            Instantiate(projectile,transform.position,transform.rotation);
            projectileCount--;
            Counter.bombNumber--;
            canShoot=false;
            StartCoroutine(Wait());
        }
    }
    public void BuyBomb(){
        if(Counter.grassDestroyed>=bombPlantRequiere && Counter.rockDestroyed>=bombRockRequiere && Counter.DeadEyeNumber>=deadEyeRequiere){
            Counter.grassDestroyed-=bombPlantRequiere;
            Counter.rockDestroyed-=bombRockRequiere;
            Counter.DeadEyeNumber--;
            projectileCount++;
            Counter.bombNumber++;
            bombSlot.SetActive(true);
        }
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(delay);
        canShoot=true;
        //Destroy(projectile,1);
    }
}
