using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDancing : MonoBehaviour
{
    int arrowsSpwaned;
    public  static int StartTheGame;
    public static int startFight=0;
    public static LifeBarManager lifeBarManager;
    public LifeBarManager manager;
    public float time;

    float chosenTime;
    public GameObject canvas;
    public GameObject ArrowUp;
    public GameObject ArrowDown;
    public GameObject ArrowLeft;
    public GameObject ArrowRight;

    public int max;

    Dictionary<int,GameObject> arrows;
    // Start is called before the first frame update
    void Start()
    {
        arrowsSpwaned=0;
        StartTheGame=max;
        startFight=0;
        chosenTime=time;
        arrows=new Dictionary<int, GameObject>();

        arrows.Add(0,ArrowUp);
        arrows.Add(1,ArrowDown);
        arrows.Add(2,ArrowLeft);
        arrows.Add(3,ArrowRight);
        ManagerDancing.StartTheGame=max;
        lifeBarManager=manager;
      //  StartCoroutine(SpwanTheArrowBro());
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;

        if(time<0){
            
            if(arrowsSpwaned<max){SpawnAnArrow();
            arrowsSpwaned++;
            }
            
            time=chosenTime;
        }
        
    }

    public IEnumerator SpwanTheArrowBro(){
        for(int i=0;i<=max;i++){
            SpawnAnArrow();
          //  startFight++;
            yield return new WaitForSeconds(time);
        }
        yield return null;
    }
    public void SpawnAnArrow(){
        int randomArrow= Random.Range(0,4);
        GameObject RandomArrow=Instantiate(arrows[randomArrow]);
       // RandomArrow.transform.parent=canvas.transform;
       // RandomArrow.transform.position=arrows[randomArrow].transform.position;
       // RandomArrow.SetActive(true);
        RandomArrow.transform.SetParent(canvas.transform);
        RandomArrow.transform.position=arrows[randomArrow].transform.position;
       RandomArrow.transform.localScale=arrows[randomArrow].transform.localScale;
        RandomArrow.SetActive(true);


    }



}
