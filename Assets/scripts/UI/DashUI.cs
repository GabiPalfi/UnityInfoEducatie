using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public Image image;
    public Platformer player;
    void Start()
    {
        image = image.GetComponent<Image>();
        player = player.GetComponent<Platformer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDashReady){
            image.color = new Color (50,50,50,255);
        }else{
            image.color = new Color32(1,1,1,50);
        }
         
    }
}
