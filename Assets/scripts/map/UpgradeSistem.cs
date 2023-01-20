using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSistem : MonoBehaviour
{   [Header("Weapons")]
    public bool katanaUpgrade2;
    public bool axeBought2;
    public bool katanaUpgrade3;
    public bool axeBought3;

    public static bool hasAxeBought2;
    public static bool hasKatanaBought2;
    public static bool hasAxeBought3;
    public static bool hasKatanaBought3;

    [Header("Resorses Weapon")]
    public int katanaPlantRequiere;
    public int katanaRockRequiere;
    public int axePlantRequiere;
    public int axeRockRequiere;

    [Header("Resorses Armor")]
    public int redArmorPlantRequiere;
    public int redArmorRockRequiere;
    public int greenArmorPlantRequiere;
    public int greenArmorRockRequiere;

    [Header("Armor")]
    public bool redArmor;
    public bool greenArmor;
    public static bool hasRedArmorbought;
    public static bool hasGreenArmorbought;

    [Header("Referinte")]
    public GameObject katana;
    public GameObject chest;
    ChestScript armor;
    Katana kat;
    public Platformer thePlayer;

    public void Start(){
        kat = katana.GetComponent<Katana>();
        thePlayer = FindObjectOfType<Platformer>();
        armor = chest.GetComponent<ChestScript>();

        if(hasKatanaBought2){
            kat.Katana2();
        }
        if(hasAxeBought2){
            kat.Axe();
        }
        if(hasKatanaBought3){
            kat.Katana3();
        }
        if(hasAxeBought3){
            kat.Axe2();
        }
        if(hasRedArmorbought){
            armor.RedArmor();
        }
        if(hasGreenArmorbought){
            armor.GreenArmor();
        }

    }
    public void Update(){
        if(hasAxeBought2){
            axeBought2=true;
        }
        if(hasKatanaBought2){
            katanaUpgrade2=true;
        }
        if(hasAxeBought3){
            axeBought3=true;
        }
        if(hasKatanaBought3){
            katanaUpgrade3=true;
        }
        if(hasKatanaBought3){
            katanaUpgrade3=true;
        }
        if(hasGreenArmorbought){
            greenArmor=true;
        }
        if(hasRedArmorbought){
            redArmor=true;
        }
    }
    
    public void AxeBought(){
        if((Counter.grassDestroyed>=axePlantRequiere && Counter.rockDestroyed>=axeRockRequiere)&&axeBought2==false){
            Counter.grassDestroyed-=axePlantRequiere;
            Counter.rockDestroyed-=axeRockRequiere;
            hasAxeBought2 = true;
            hasKatanaBought2=false;
            hasKatanaBought3 = false;
            hasAxeBought3=false;
            //thePlayer.playerDamage+=40;
            kat.Axe();
        }
    }

    public void KatanaBought(){
        if((Counter.grassDestroyed>=katanaPlantRequiere && Counter.rockDestroyed>=katanaRockRequiere)&&katanaUpgrade2==false){
            Counter.grassDestroyed-=katanaPlantRequiere;
            Counter.rockDestroyed-=katanaRockRequiere;
            hasKatanaBought2 = true;
            hasAxeBought2=false;
            hasAxeBought3=false;
            hasKatanaBought3 = false;
            //thePlayer.playerDamage+=20;
            kat.Katana2();
        }
    }
    public void KatanaBought2(){
        if((Counter.grassDestroyed>=katanaPlantRequiere && Counter.rockDestroyed>=katanaRockRequiere)&&katanaUpgrade3==false){
            Counter.grassDestroyed-=katanaPlantRequiere;
            Counter.rockDestroyed-=katanaRockRequiere;
            hasKatanaBought3 = true;
            hasKatanaBought2=false;
            hasAxeBought2 =false;
            hasAxeBought3=false;
            //thePlayer.playerDamage+=20;
            kat.Katana3();
        }
    }
    public void AxeBought2(){
        if((Counter.grassDestroyed>=axePlantRequiere && Counter.rockDestroyed>=axeRockRequiere)&&axeBought3==false){
            Counter.grassDestroyed-=axePlantRequiere;
            Counter.rockDestroyed-=axeRockRequiere;
            hasAxeBought3 = true;
            hasAxeBought2=false;
            hasKatanaBought2=false;
            hasKatanaBought3=false;
            //thePlayer.playerDamage+=40;
            kat.Axe2();
        }
    }
    public void GreenArmorBought(){
        if((Counter.grassDestroyed>=greenArmorPlantRequiere && Counter.rockDestroyed>=greenArmorRockRequiere)&&greenArmor==false){
            Counter.grassDestroyed-=greenArmorPlantRequiere;
            Counter.rockDestroyed-=greenArmorRockRequiere;
            hasGreenArmorbought = true;
            armor.GreenArmor();
            hasRedArmorbought=false;
        }
    }
    public void RedArmorBought(){
        if((Counter.grassDestroyed>=redArmorPlantRequiere && Counter.rockDestroyed>=redArmorRockRequiere)&&redArmor==false){
            Counter.grassDestroyed-=redArmorPlantRequiere;
            Counter.rockDestroyed-=redArmorRockRequiere;
            hasRedArmorbought = true;
            armor.RedArmor();
            hasGreenArmorbought=false;
        }
    }
}
