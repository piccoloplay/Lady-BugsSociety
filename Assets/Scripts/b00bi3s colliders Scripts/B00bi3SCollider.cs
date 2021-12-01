using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B00bi3SCollider : MonoBehaviour
{

    
    public bool B00bi3S;
    public Avatar avatar;
    
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
   


    private void OnCollisionEnter(Collision other) {
        
            if(!animator.GetComponent<Avatar>().defense){
                if(avatar.player1){
             collisioneBottaFratelli(other,"opponent2");
            // collisioneBottaFratelli(other,"opponent2");
             }else{
              collisioneBottaFratelli(other,"opponent1");
            // collisioneBottaFratelli(other,"opponent1");
            }
            }
            
        
         
    }


    public void collisioneBottaFratelli(Collision other, string opponent){
        if(other.gameObject.tag==opponent){
            Debug.LogWarning("HITTTTTO");
            animator.Play("hit");
            DamageCalucaltion(other);
        }
    }


    public void DamageCalucaltion(Collision other){
        Avatar opponent=other.gameObject.GetComponent<WeaponCollider>().avatar;
        
        float damage=opponent.Atk-avatar.Def;
        if(damage<=4)damage=5;
        Debug.LogWarning(damage+" DAMAGE");
        avatar.ActualHp=avatar.ActualHp-damage;
        
       
    }
}
