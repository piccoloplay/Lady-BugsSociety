using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUController : MonoBehaviour
{
     int[]moves;
    int []attacks;
    //public GameObject colliderWeaponOpponent;
    public GameObject colliderWeapon;
    public float decisionTime;

    float timeChosen;
    public bool direction;
     public float m_Speed;
     Rigidbody m_Rigidbody;
     public Animator animator;

     public GameObject Avatar;
    // Start is called before the first frame update


    private void Awake() {
        moves=new int[10];
        attacks=new int[10];
        for(int i=0;i<10;i++){
            int abuelo=i;
            int pepito=i;
            switch(pepito){
                case  0:
                attacks[i]=0;
                break;
                case 1:
                 attacks[i]=0;
                break;
                case 2:
                 attacks[i]=1;
                break;
                case  3:
                 attacks[i]=1;
                break;
                case 4:
                 attacks[i]=1;
                break;
                case 5:
                 attacks[i]=2;
                break;
                case  6:
                 attacks[i]=2;
                break;
                case 7:
                 attacks[i]=1;
                break;
                case 8:
                 attacks[i]=1;
                break;
                case 9:
                 attacks[i]=1;
                break;
            }
            switch(abuelo){
                case  0:
                moves[i]=0;
                break;
                case 1:
                 moves[i]=0;
                break;
                case 2:
                 moves[i]=0;
                break;
                case  3:
                 moves[i]=0;
                break;
                case 4:
                 moves[i]=2;
                break;
                case 5:
                 moves[i]=2;
                break;
                case  6:
                 moves[i]=0;
                break;
                case 7:
                 moves[i]=1;
                break;
                case 8:
                 moves[i]=0;
                break;
                case 9:
                 moves[i]=1;
                break;
            }
            
        }
    }




    void Start()
    {
        colliderWeapon=Avatar.GetComponent<Avatar>().collider;
        timeChosen=decisionTime;
         m_Rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // colliderWeaponOpponent.SetActive(false);
        // tieni traccia della distanza
        // se la distanza e' minima attacc
        // altrimenti muoviti
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Block")) {
            Avatar.GetComponent<Avatar>().defense=true;}else{
            Avatar.GetComponent<Avatar>().defense=false;
            }

         if(animator.GetCurrentAnimatorStateInfo(0).IsName("attackV")){
                colliderWeapon.SetActive(true);
         } else if(animator.GetCurrentAnimatorStateInfo(0).IsName("attackL")){
             colliderWeapon.SetActive(true);
         }   else{
             colliderWeapon.SetActive(false);
         }

         
        decisionTime -= Time.deltaTime;
        if ( decisionTime < 0 )
        {
            int randAttack=Random.Range(0,10); /// fai un metodo
            
            Block(attacks[randAttack]);
             //Block(0);
           VerticalAttack(attacks[randAttack]);
           //VerticalAttack(1);
            LateralAttack(attacks[randAttack]);

            int randMovement=Random.Range(0,10);
            // Debug.LogWarning(rand);
            Movement(moves[randMovement]);     /// fai un metodo
            decisionTime=timeChosen;
            //if(randAttack==0) decisionTime=Random.Range(0,4);
        }
        
    }

     public void Jump(){
            if(transform.position.y==1){
                 transform.Translate(Vector3.up*0.7f);
            }
        }
public void Block(int attack){
    if(attack==0){
                    animator.SetBool("Block",true);
                  
                  
                    
                    
            }else{
                animator.SetBool("Block",false);
               
                
                    
            }
}
public void VerticalAttack(int attack){
// ATTACCO1
       if(attack==1){
            
            animator.SetBool("one",true);
             m_Rigidbody.velocity=transform.right*m_Speed;
           
        }else{
            //colliderWeapon.SetActive(false);
            animator.SetBool("one",false);
           
        }
}

public void LateralAttack(int attack){
    if(attack==2){
              //  colliderWeapon.SetActive(true);
                animator.SetBool("two",true);
                m_Rigidbody.velocity=-transform.right*m_Speed/2;
            
            }else{
              //  colliderWeapon.SetActive(false);
                animator.SetBool("two",false);
            
            }
}
public void Movement(int move){
 ////// MOVEMENT
       //  animator.SetBool("movement",true);
        
         if (move==0)
        {
            //Rotate the sprite about the Y axis in the positive direction
           // transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed, Space.World);
          if(transform.position.y>1){
            m_Rigidbody.velocity=-transform.right*m_Speed-transform.up*2.5f    ;  
          }else{
              m_Rigidbody.velocity=-transform.right*m_Speed;
          }
            
           
        }

        else if (move==1)
        {
            //Rotate the sprite about the Y axis in the negative direction
           // transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * m_Speed, Space.World);
           
          if(transform.position.y>1){
              // se e' in aria
            m_Rigidbody.velocity=transform.right*m_Speed-transform.up*2.5f    ;  
          }else{
              m_Rigidbody.velocity=transform.right*(m_Speed+0.25f);
          }
            
        }else if(move==2){
           Jump();
        }else{

        }
        }
    }


