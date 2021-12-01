using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControllerPhysics : MonoBehaviour
{
    public Avatar myAvatar;
    float dirX;
	float moveSpeed = 20f;
    public float timerMovement;
    float timeChosen;
    public TMP_Text angolo;
    float lastAngle;
    float actualAngle;

    //public GameObject colliderWeaponOpponent;
   // bool COMBAT=false;
   public GameObject colliderWeapon;
  // public GameObject colliderEnemy;
    Rigidbody m_Rigidbody;
    public float m_Speed;
    public GameObject Avatar;
    public Animator animator;

    public bool direction;
    void Start()
    {
        
        timeChosen=timerMovement;
        actualAngle=0;
        lastAngle=0;
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
      //  m_Speed = 2.0f;
     
    }
    public void settaCollider(){
        colliderWeapon=myAvatar.collider;
    }


  
    void Update()
    {
        
       // Block();
       //VerticalAttack();
       //LateralAttack();
      // if(animator.GetCurrentAnimatorStateInfo(0).IsName("attackV")){
       //         colliderWeapon.SetActive(true);
        // } else if(animator.GetCurrentAnimatorStateInfo(0).IsName("attackL")){
        //     colliderWeapon.SetActive(true);
        // }   else{
         //    colliderWeapon.SetActive(false);
        // }
       
       //  if(!this.animator.GetCurrentAnimatorStateInfo(0).IsName("attackV")){
       //      if(!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Block")){
       //           if(!this.animator.GetCurrentAnimatorStateInfo(0).IsName("hit")){
        //               if(!this.animator.GetCurrentAnimatorStateInfo(0).IsName("attackL")){
        //                    Movement();
        //               }
                        //animator.SetBool("hit",false);
                        

                    // Round(); 
          //        }
                    
           //  }
           
         //}
       
      
         
    }

public void Block(){
    if(Input.GetKey(KeyCode.W)){
                    animator.SetBool("Block",true);
                  //  colliderEnemy.SetActive(false);
                 //   colliderWeaponOpponent.SetActive(false);
                 Avatar.GetComponent<Avatar>().defense=true;
                    
            }else{
                animator.SetBool("Block",false);
                Avatar.GetComponent<Avatar>().defense=false;
           //     colliderWeaponOpponent.SetActive(true);
           
            }
}
public void VerticalAttack(){
// ATTACCO1
       
            
            animator.SetBool("one",true);
             m_Rigidbody.velocity=transform.right*m_Speed;
             
           
     
        //    animator.SetBool("one",false);
           
      
}

public void LateralAttack(){

            
            animator.SetBool("two",true);
             m_Rigidbody.velocity=-transform.right*m_Speed/2;
           
        
        //    animator.SetBool("two",false);
           
        
}

    public IEnumerator attack1(){
        
        yield return null;
    }

    public void Round(){
        if(Input.GetKeyDown(KeyCode.D)&&direction){
            Avatar.transform.rotation=Quaternion.Euler(0,-90,0);
            direction=false;
        }else if(Input.GetKeyDown(KeyCode.D)&&!direction){
            Avatar.transform.rotation=Quaternion.Euler(0,90,0);
                direction=true;
        }
    }


    public void Movement(){
 ////// MOVEMENT
         animator.SetBool("movement",true);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward ;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward ;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
           // transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed, Space.World);
          if(transform.position.y>1){
            m_Rigidbody.velocity=transform.right*m_Speed-transform.up*2.5f    ;  
          }else{
              m_Rigidbody.velocity=transform.right*m_Speed;
          }
            
           
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
           // transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * m_Speed, Space.World);
           
          if(transform.position.y>1){
              // se e' in aria
            m_Rigidbody.velocity=-transform.right*m_Speed-transform.up*2.5f    ;  
          }else{
              m_Rigidbody.velocity=-transform.right*(m_Speed+0.25f);
          }
            
        }else if(Input.GetKeyDown(KeyCode.Space)){
            m_Rigidbody.velocity=transform.up*4;
        }else if(Input.GetKeyDown(KeyCode.A)&&direction){
            Avatar.transform.rotation=Quaternion.Euler(0,-90,0);
            direction=false;
        }else if(Input.GetKeyDown(KeyCode.A)&&!direction){
            Avatar.transform.rotation=Quaternion.Euler(0,90,0);
                direction=true;
        }else {
              animator.SetBool("movement",false);
        }
    }
}
