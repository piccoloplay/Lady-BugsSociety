using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChosenCharacter : MonoBehaviour
{
//public bool bossFinale;
    public List<GameObject> dancers;
public int randomOpponent;
public RawImage profiloOpponent;
public Image barraVitaOpponent;

public Transform player2;
public CPUController cPUController;
public RawImage profilo;
public Image barraVita;

public List<GameObject> opponents;

    public List<Texture>profili;
public List<Sprite> Barravita;
    public ControllerPhysics Player1Cube;
    public Transform player1;
    public Dictionary<int,GameObject> bugs;
    public GameObject Mantis;
    public GameObject Bee;
    public GameObject LadyBug;

    public GameObject MosquitoJoe;
    public GameObject Butterfly;
    public GameObject Caterpillar;

    public GameObject DragonFly;
    // Start is called before the first frame update
    private void Awake() {
        // HashBugs();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int bossFinale(int boss, int random){
        Scene scene=SceneManager.GetActiveScene();
        if(scene.buildIndex==boss){
            return 7;
        }else{
            return random;
        }
        
    }
    public int miniBoss(int boss, int random){
        Scene scene=SceneManager.GetActiveScene();
        if(scene.buildIndex==boss){
            return 8;
        }else{
            return random;
        }
        
    }


    public void estraiOpponent(){
        randomOpponent=Random.Range(0,7);
        
        randomOpponent=bossFinale(6,randomOpponent);
        randomOpponent=miniBoss(5,randomOpponent);

        opponents[randomOpponent].SetActive(true);
        opponents[randomOpponent].transform.position=player2.position;
        opponents[randomOpponent].transform.rotation=player2.rotation;
        cPUController.animator=opponents[randomOpponent].GetComponent<Animator>();
        cPUController.Avatar=opponents[randomOpponent];
        profiloOpponent.texture=profili[randomOpponent];
        barraVitaOpponent.sprite=Barravita[randomOpponent];
    }


    public void HashBugs(){
        estraiOpponent();
        bugs=new Dictionary<int, GameObject>();
        bugs.Add(0,DragonFly);
        bugs.Add(1,Bee);
        bugs.Add(2,LadyBug);
        bugs.Add(3,Mantis);
        bugs.Add(4,MosquitoJoe);
        bugs.Add(5,Butterfly);
        bugs.Add(6,Caterpillar);
        Sposta();
    }


    public void Sposta(){
        profilo.texture=profili[MenuChoice.character];
        //=Barravita[MenuChoice.character];
        barraVita.sprite=Barravita[MenuChoice.character];
        bugs[MenuChoice.character].SetActive(true);
        bugs[MenuChoice.character].transform.position=player1.position;
        bugs[MenuChoice.character].transform.rotation=player1.rotation;
        Player1Cube.myAvatar=bugs[MenuChoice.character].GetComponent<Avatar>();
        Player1Cube.settaCollider();
    }





}
