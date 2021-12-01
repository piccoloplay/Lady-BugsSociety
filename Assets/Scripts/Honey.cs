using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Honey : MonoBehaviour
{
    public List<GameObject>bees;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene=SceneManager.GetActiveScene();
        if(scene.buildIndex==5)Bees();
        
    }


    public void Bees(){
        foreach(GameObject bee in bees){
            bee.SetActive(true);
            
        }
        if(LifeBarManager.gameFinisched){
            bees[0].GetComponent<Animator>().Play("sederino");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
