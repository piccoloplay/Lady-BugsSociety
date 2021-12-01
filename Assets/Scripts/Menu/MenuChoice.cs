using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuChoice : MonoBehaviour
{
    public static int fightScene;
    public TMP_Text identity;
    public TMP_Text type;
    public TMP_Text name;
    public GameObject caterpi;
    public GameObject butter;
    public bool butterfly;
    public static int character;
    public GameObject Mantis;
    public GameObject LadyBug;
    public GameObject Mosquito;

    public GameObject ButterFly;

    public GameObject Dragonfly;

    public GameObject Bee;

    public GameObject Caterpillar;

    public GameObject Active;
    // Start is called before the first frame update
    void Start()
    {
        fightScene=2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
// 0
    public void showDragoFly(){
        name.text="NAMe: Lenna Forsen";
        type.text="Lady-Dragonfly";
        identity.text="BISEXUAL";
        Active.SetActive(false);
        Active=Dragonfly;
        Dragonfly.SetActive(true);
        character=0;
    }
// 1
    public void showBee(){
        name.text="NAMe: Cleo Bee Patra";
          type.text="Lady-Bee";
          identity.text="PANSEXUAL";
        Active.SetActive(false);
        Active=Bee;
        Bee.SetActive(true);
        character=1;
    }

// 2
    public void showLadyBug(){
        name.text="NAMe: Greta HellMberg";
         type.text="Lady-Ladybug";
         identity.text="ASEXUAL";
        Active.SetActive(false);
        Active=LadyBug;
        LadyBug.SetActive(true);
        character=2;
    }
// 3
    public void showMantis(){
        name.text="NAMe: Mother ThereZa";
         type.text="Lady-Mantis";
         identity.text="AROMANTIC";
        Active.SetActive(false);
        Active=Mantis;
        Mantis.SetActive(true);
        character=3;
    }
// 4
    public void showMosquito(){
        name.text="NAMe: Mosquito Joe";
        type.text="LadyBoy-Mosquito";
        identity.text="GENDERQUEER";
        Active.SetActive(false);
        Active=Mosquito;
        Mosquito.SetActive(true);
        character=4;
    }
// 5
    public void showButterfly(){
        if(butterfly){
            name.text="NAMe: Nicky Minajj";
            type.text="Lady-Butterfly";
            identity.text="LESBIAN";
            Active.SetActive(false);
             Active=ButterFly;
             ButterFly.SetActive(true);
            character=5;
            butter.SetActive(true);
            caterpi.SetActive(false);
             butterfly=false;
        }else{
            name.text="NAMe: Nicky Minajj";
            identity.text="LESBIAN";
            type.text="Lady-Caterpillar";
            Active.SetActive(false);
            Active=Caterpillar;
            Caterpillar.SetActive(true);
            character=6;
            caterpi.SetActive(true);
            butter.SetActive(false);
            butterfly=true;
        }
        
    }



    public void StartGame(){
        SceneManager.LoadScene("LOADING");
    }
}
