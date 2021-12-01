using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpBugs : MonoBehaviour
{
    public GameObject ragnatela;
    public List<Transform>position;
    
    public List<GameObject>insectos;
    // Start is called before the first frame update
    void Start()
    {
        SpawnInsectos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnInsectos(){
        int count=3;
        
        while(count>0){
            count--;
            int randomIndex=Random.RandomRange(0,7);
            GameObject insecto=Instantiate(insectos[randomIndex]);
            insecto.transform.SetParent(ragnatela.transform);
            insecto.transform.position=position[count].position;
            insecto.transform.rotation=position[count].rotation;
            insecto.transform.localScale=position[count].localScale;

        }
    }
}
