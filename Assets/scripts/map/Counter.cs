﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static int grassDestroyed;
    public static int rockDestroyed;
    public static int enemyKilled;
    public static int bombNumber;
    public static int DeadEyeNumber;
    public static int dificulty=1;
    public static bool SoundOn;
    public static bool DashObtained;
    public static bool isLibocaKilled;

    public void Update(){
        if(SoundOn==false){
            AudioListener.pause = false;
        }
    }
  
    
}
