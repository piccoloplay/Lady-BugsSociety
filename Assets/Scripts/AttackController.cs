using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public AudioSource vertical;
    public AudioSource lateral;
    public Defenser defesen;
    
    public LifeBarManager manager;
    Animator animator;
    Rigidbody m_Rigidbody;
    GameObject Player_Controller;
    float timer=0.25f;

    // Start is called before the first frame update
    void Start()
    {
        animator=manager.Player1.GetComponent<Animator>();
        m_Rigidbody=manager.Player_Controller.GetComponent<Rigidbody>();
        Player_Controller=manager.Player_Controller;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(defesen.buttonPressed==false){
                animator.SetBool("Block",false);
                manager.Player1.defense=false;
        }else{
            Block();
        }
        timer-=Time.deltaTime;
        if(timer<0){
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle")){
           Player_Controller.GetComponent<ControllerPhysics>().colliderWeapon.SetActive(false);
            //animator.SetBool("Block",false);
           //     Avatar.GetComponent<Avatar>().defense=false;
        }

        timer=0.25f;
        }
        
        // if(!animator.GetCurrentAnimatorStateInfo(0).IsName("attackL")){
        //     animator.SetBool("two",false);
        // }
    }

    public void VerticalAttack(){
    // ATTACCO1
       
            vertical.Play();
            animator.Play("attackV");
          //   m_Rigidbody.velocity=transform.right*m_Speed;
             
            Player_Controller.GetComponent<ControllerPhysics>().colliderWeapon.SetActive(true);
          //  animator.GetComponent<Avatar>().vertical.Play();
        //    animator.SetBool("one",false);
    }

    public void LateralAttack(){

            lateral.Play();
             animator.Play("attackL");
            // m_Rigidbody.velocity=-transform.right*m_Speed/2;
            Player_Controller.GetComponent<ControllerPhysics>().colliderWeapon.SetActive(true);
           // animator.GetComponent<Avatar>().lateral.Play();
        //    animator.SetBool("two",false);
           
        
}

public void Jump(){
    if(Player_Controller.transform.position.y==1){
             Player_Controller.transform.Translate(Vector3.up*0.7f);
    }
   
    
}
public void Block(){

       animator.SetBool("Block",true);
        manager.Player1.defense=true;
       

}
      

}
