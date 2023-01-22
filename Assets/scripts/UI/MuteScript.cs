using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    private bool isMuted;
    // Start is called before the first frame update
    void Start()
    {
        isMuted=false;
    }

    public void MutePressed(){
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        Counter.SoundOn = !Counter.SoundOn;
    }
}
