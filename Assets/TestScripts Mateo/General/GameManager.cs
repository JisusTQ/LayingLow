using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject alien;
    AlienStatus alienStatus;
    float timeRemaining=30;
    public bool isCorpse;
    public bool corpseActivates;
    // Start is called before the first frame update
    void Start()
    {
        alien = GameObject.FindGameObjectWithTag("alien");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeMelting();
        if(corpseActivates){
            StartCoroutine(CorpseDuration());
        }
    }


    private void TimeMelting(){
        timeRemaining-= Time.fixedDeltaTime;
    }

    IEnumerator CorpseDuration(){
        corpseActivates=false;
        timeRemaining+=5;
        yield return new WaitForSeconds(8);
        isCorpse=false;
    }

    private void TimeIsOver(){
        if (timeRemaining<0){
            SceneManager.LoadScene("");
        } 
    }

    
}
