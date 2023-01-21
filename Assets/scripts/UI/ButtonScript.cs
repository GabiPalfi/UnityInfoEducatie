using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip ring;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void IsSelected(){
        anim.SetBool("Selected",true);
        SoundManager.Instance.PlaySound(ring);
    }
    public void IsDeSelected(){
        anim.SetBool("Selected",false);
        //SoundManager.Instance.PlaySound(ring);
    }
    public void IsPressed(){
        SoundManager.Instance.PlaySound(ring);
        anim.SetBool("Presed",true);
        
    }
}
