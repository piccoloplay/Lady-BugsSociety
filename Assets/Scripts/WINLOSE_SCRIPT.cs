using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class WINLOSE_SCRIPT : MonoBehaviour
{
    public TMP_Text testoWin;
    public float timer;
    public RawImage winlose;

    public List<Texture> winners;
    public List<Texture> losers;


    public List<Texture> winnersAlt;
    public List<Texture> loserserAlt;
    private void Awake() {
        if(LifeBarManager.winLose){
            if(LifeBarManager.gameFinisched){
                winlose.texture=winnersAlt[MenuChoice.character];
                testoWin.text="YOU WIN!";
            }else{
                winlose.texture=winners[MenuChoice.character];
                testoWin.text="YOU WIN!";
            }
            
        }else{
            if(LifeBarManager.gameFinisched){
                winlose.texture=loserserAlt[MenuChoice.character];
            testoWin.text="YOU LOSE..";
            }else{
                winlose.texture=losers[MenuChoice.character];
            testoWin.text="YOU LOSE..";
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<0){
            SceneManager.LoadScene("LOADING");
        }
    }
}
