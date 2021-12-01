using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LOADING_SCREEN : MonoBehaviour
{
    public RawImage wall;
    public float timerPuntino;
    float timechoose;
    public TMP_Text Loading;
    
    public List<string> loadingText;
    public int index;
    int count;
    public List<Texture> images;
    // Start is called before the first frame update
    

    public void RandomImagesLoading(){
        int randomIndex=Random.Range(0,images.Count);
        wall.texture=images[randomIndex];
    }
    private void Awake() {
        RandomImagesLoading();
        index=0;
        count=0;
        timechoose=timerPuntino;
       // SceneManager.LoadSceneAsync(2);// PINZA PER LA SCELTA GIUSTA DELLA SCENA.
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerPuntino-=Time.deltaTime;

        if(timerPuntino<0){
            Loading.text=loadingText[index];
            index++;
            index=index%3;
            count++;
            if(count==7){

                if(MenuChoice.fightScene==7){
                        SceneManager.LoadScene(0);
                }else{
                    SceneManager.LoadSceneAsync(MenuChoice.fightScene);
                }
                
            }
            timerPuntino=timechoose;
        }

    }




}
