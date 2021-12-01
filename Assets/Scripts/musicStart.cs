using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicStart : MonoBehaviour
{
    // 16.5 demonslayer 
    public float time;
    //public AudioSource ReaadyyDance;
    public AudioSource music;
    public float timer;
    //bool t=true;
    
    // Start is called before the first frame update
    void Start()
    {
        music.time=time;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

   
}
