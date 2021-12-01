using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{

    
    public GameObject collider; 
    public bool defense;
    public bool player1;
    public float Hp;

    public float ActualHp;

    // formula danno Hp= atk - def
    public float Atk;
    public float Def;

//   speed di movimento nel mondo
    public float speed;

    public float Fattore_Animazione_Speed;
    public Transform Opponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(Opponent);
    }


    public float DamageRecevied(){
        return 0;
    }
    public float ActualHP(){
        float result=this.ActualHp / this.Hp;
        return result;
    }
}
