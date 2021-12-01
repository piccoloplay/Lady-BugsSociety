using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BubbleDancing : MonoBehaviour
{
    public TMP_Text player;
    public TMP_Text oppo;
    bool t;
    public LifeBarManager lifeBarManager;
    public Avatar player1;
    public Avatar player2;
    bool checkDestruction=false;
    bool pressed=true;
    public KeyCode arrow;
    // 380- 400 GOOD 401 -420 Perfect
    public GameObject pedinaBoss;

    public GameObject pedinaReddo;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        t=true;
        lifeBarManager=ManagerDancing.lifeBarManager;
        player1=lifeBarManager.Player1;
        player2=lifeBarManager.Player2;
        //speed=2;
    }

    // Update is called once per frame
    void Update()
    {GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y-speed);
        if(Input.GetKeyDown(arrow)&&pressed){
            float valy=GetComponent<RectTransform>().anchoredPosition.y*-1;
            
            ChangeColour();
         //  StartCoroutine(Green());
        }
        DestructionExplosion();
        
    }




    

    public void ChangeColour(){
        float valy=GetComponent<RectTransform>().anchoredPosition.y*-1;
            
        
            if((valy>=370)&(valy<=400)){
                  //  pedinaBoss.SetActive(false);
                    Debug.LogWarning("GOOD");
                    StatGood();
                     player.color=Color.green;
                    player.text="GOOD";
                  //  GameObject.Find("GoodPerfect").GetComponent<TMP_Text>().text="GOOD";
                   // Destroy(GetComponent<Image>());
                   pressed=false;
                   pedinaBoss.GetComponent<Animator>().Play("Green");
                  //  yield return new WaitForSeconds(0.15f);
                  //  pedinaBoss.SetActive(true);
                    
                  //  Destroy(this);
            }else if((valy>=401)&(valy<=430)){
                //pedinaBoss.SetActive(false);
                    Debug.LogWarning("PERFETCT");
                    StatPerfect();
                    player.color=Color.magenta;
                    player.text="PERFECT";
                    //GameObject.Find("GoodPerfect").GetComponent<TMP_Text>().text="PERFECT";
                     pressed=false;
                     pedinaBoss.GetComponent<Animator>().Play("Green");
                    //Destroy(GetComponent<Image>());
                //    yield return new WaitForSeconds(0.15f);
                //    pedinaBoss.SetActive(true);
                    
                    // Destroy(this);
            }else if(valy>=440){
                    pressed=false;
                    pedinaBoss.GetComponent<Animator>().Play("Red");
                    StatMiss();
                    player.color=Color.red;
                    player.text="MISS";
                    // GameObject.Find("GoodPerfect").GetComponent<TMP_Text>().text="MISS";
                  //  pedinaReddo.SetActive(true);
                //    yield return new WaitForSeconds(0.15f);
                 //   pedinaReddo.SetActive(false);
            }
           checkDestruction=true;
    }

    public void DestructionExplosion(){
            float valy=GetComponent<RectTransform>().anchoredPosition.y*-1;
            if(valy>500){
                // 
                player.text="";
                oppo.text="";
                ManagerDancing.startFight++;
                if(ManagerDancing.StartTheGame==ManagerDancing.startFight){
                    ManagerDancing.lifeBarManager.FightModo();
                }
                Destroy(this.gameObject);
            }
    }

    public void IncrementStat(Avatar avatar, float atk, float def, float hp){
        if(!(avatar.ActualHp>=100))avatar.ActualHp+=hp;
        
        avatar.Atk+=atk;
        avatar.Def+=def;
    }

    public void StatPerfect(){      
        IncrementStat(player1,1f,1f,2.5f);
        // IncrementStat(player2,2.5f,2.5f,2.5f);
        // inserisci stesso metodo
        //LanciaLamonetina();
        EnemyGuess();
    }

        public void StatGood(){
            IncrementStat(player1,0.25f,0.25f,0.5f);
            // IncrementStat(player2,0.25f,0.25f,0.5f);
            // inserisci stesso metodo
             //LanciaLamonetina();
             EnemyGuess();
        }    

        public void StatMiss(){
            IncrementStat(player1,-0.25f,-0.25f,0f);
            //IncrementStat(player2,-0.25f,-0.25f,0f);
            // inserisci stesso metodo
            EnemyGuess();
             
        }

        public void LanciaLamonetina(){
            int monetina=Random.Range(0,3);
            switch(monetina){
                case 0:
                     IncrementStat(player2,2.5f,2.5f,2.5f);
                     oppo.color=Color.magenta;
                     oppo.text="PERFECT";
                    break;
                case 1:
                    IncrementStat(player2,0.25f,0.25f,0.5f);
                    oppo.color=Color.green;
                     oppo.text="GOOD";
                    break;
                case 2:
                    IncrementStat(player2,-0.25f,-0.25f,0f);
                    oppo.color=Color.red;
                     oppo.text="MISS";
                    break;
            }

        }

    public void EnemyGuess(){
            float valy=GetComponent<RectTransform>().anchoredPosition.y*-1;
            if(valy<=440&&t){
                LanciaLamonetina();
                    t=false;
            }

    }


}
