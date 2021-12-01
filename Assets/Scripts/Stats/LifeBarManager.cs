using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeBarManager : MonoBehaviour
{
    public static bool gameFinisched;
    
    bool danceFinisched;
    public static bool winLose;
    GameObject oppoDancer;
     GameObject playerDancer;
    public ChosenCharacter character;
    public Transform position1;
    public Transform position2;

    public Transform positionDance1;
    public Transform positionDance2;
    bool t;
    public List<GameObject> FightObjects;
    public List<GameObject> DanceObjects;
    public ManagerDancing dancing;
    public float firstTimer;
    public Image Player1Hp;
    public Image Player2Hp;
    public  Avatar Player1;
    public  Avatar Player2;
    

    GameObject Cpu_Controller;

    public GameObject Player_Controller;
// Start is called before the first frame update

    void Awake()
    {
        danceFinisched=false;
        character.HashBugs();
        t=true;
        Player1=GameObject.FindGameObjectWithTag("Player1").GetComponent<Avatar>();
        Player2=GameObject.FindGameObjectWithTag("Player2").GetComponent<Avatar>();
       // Player2=FindObjectOfType<Avatar>(tag.Equals("Player2"));
        Cpu_Controller= GameObject.FindGameObjectWithTag("CpuController");
        Player_Controller=GameObject.FindGameObjectWithTag("PlayerController");
        Cpu_Controller.GetComponent<CPUController>().enabled=false;
        Player_Controller.GetComponent<ControllerPhysics>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        Player1Hp.fillAmount=Player1.ActualHP();
        Player2Hp.fillAmount=Player2.ActualHP();

        // metodo carica scena vincita.
       winCondition();
        firstTimer-=Time.deltaTime;
        if(firstTimer<0&&t){
           DanceModo();
           t=false;
        }
        
    }
public void winCondition(){
    if(danceFinisched){
        if(Player2Hp.fillAmount==0){
            winLose=true;
            MenuChoice.fightScene++;
            
            Scene scene =SceneManager.GetActiveScene();
            int scenaIndex=scene.buildIndex;
            if(scenaIndex==6)gameFinisched=true;// index boss da mettere giusto


            SceneManager.LoadScene("winlose");
        }else if(Player1Hp.fillAmount==0){
            winLose =false;
            MenuChoice.fightScene=1;
            SceneManager.LoadScene("winlose");
        }
    }
}
    public void SetUpDifficulty(){

        Scene scene=SceneManager.GetActiveScene();
        int scena=scene.buildIndex;
        Debug.LogWarning("SCENA ATTUALE = "+scena);
        switch(scena){
            case 2:
            Player1.ActualHp+=30;
            Player2.ActualHp+=40;
            Player2.Def+=20f;
            break;
            case 3:
            Player1.ActualHp+=30;
            Player2.ActualHp+=50;
            Player2.Atk+=5f;
            Player2.Def+=20;
            break;
            case 4:
            Player1.ActualHp+=30;
            Player2.ActualHp+=55;
            Player2.Def+=20;
            Player2.Atk+=5;
            break;
            case 5:
            Player1.ActualHp+=35;
            Player2.ActualHp+=60;
            Player2.Atk+=10;
            Player2.Def+=20f;
            break;
            case 6:
            Player1.ActualHp+=50;
            Player2.ActualHp+=85;
            Player2.Atk+=22.5f;
            Player2.Def+=4;
            break;


        }
    }

    public void DanceModo(){
        // metodo Pinza a seconda del livello per impostare la difficolta
        SetUpDifficulty();
        //Player1.ActualHp+=30;
        //Player2.ActualHp+=50;
        Player1.GetComponent<Animator>().Play("dance");
         Player2.GetComponent<Animator>().Play("dance");
        foreach(GameObject g in FightObjects){
            g.SetActive(false);
        }
        foreach(GameObject g in DanceObjects){
            g.SetActive(true);
        }
        positionDance1.gameObject.SetActive(false);
        positionDance2.gameObject.SetActive(false);
        oppoDancer= Instantiate(character.dancers[character.randomOpponent]);
       playerDancer=  Instantiate(character.dancers[MenuChoice.character]);
      
        Cpu_Controller.SetActive(false);
        Player_Controller.SetActive(false);
        playerDancer.gameObject.transform.position=positionDance1.position;
        oppoDancer.gameObject.transform.position=positionDance2.position;
         playerDancer.GetComponent<Animator>().Play("dance");
         oppoDancer.GetComponent<Animator>().Play("dance");
        dancing.enabled=true;

        
    }


    public void FightModo(){
        oppoDancer.SetActive(false);
        playerDancer.SetActive(false);
        dancing.enabled=false;
        foreach(GameObject g in DanceObjects){
            g.SetActive(false);
        }
        foreach(GameObject g in FightObjects){
            g.SetActive(true);
        }
         Cpu_Controller.SetActive(true);
        Player_Controller.SetActive(true);
        Cpu_Controller.GetComponent<CPUController>().enabled=true;
        Player_Controller.GetComponent<Spaceship>().enabled=true;
//        Player1.gameObject.transform.position=position1.position;
 //       Player2.gameObject.transform.position=position2.position;
        Player1.GetComponent<Animator>().Play("idle");
         Player2.GetComponent<Animator>().Play("idle");
         danceFinisched=true;


    }



}
