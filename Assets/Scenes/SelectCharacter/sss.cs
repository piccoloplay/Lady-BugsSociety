using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sss : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer=5;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<0){
        SceneManager.LoadScene(1);
        }
        
    }
}
