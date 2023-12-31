using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    AlienStatus alienStatus;
    AlienSus alienSus;
    CanPosses alienposses;
    AudioManager audiop;
    GameObject gameManager;

    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        alienStatus = GetComponent<AlienStatus>();
        alienSus = GetComponent<AlienSus>();
        alienposses = GetComponent<CanPosses>();
        audiop = FindAnyObjectByType<AudioManager>();
    }
    void Update()
    {
        TempChangeStatus();
    }

    ///<summary>
    ///Description: This is a temporary status control <br/>
    ///Input: None <br/>
    ///Return: None
    ///</summary>
    private void TempChangeStatus(){
        if (!gameManager.GetComponent<GameManager>().isCorpse){
            alienStatus.SetForm(AlienStatus.Form.alien);
            alienSus.HowSus();
        }
        if (Input.GetKeyDown("x")){
            string bodyTaken = alienposses.Posses();
            if (bodyTaken=="male")
            {
                audiop.PlaySFX(audiop.scientist);
                gameManager.GetComponent<GameManager>().isCorpse = true;
                gameManager.GetComponent<GameManager>().corpseActivates= true;
                alienStatus.SetForm(AlienStatus.Form.malecorpse);
            }
            else if(bodyTaken == "female")
            {
                audiop.PlaySFX(audiop.scientist);
                gameManager.GetComponent<GameManager>().isCorpse= true;
                gameManager.GetComponent<GameManager>().corpseActivates= true;
                alienStatus.SetForm(AlienStatus.Form.femalecorpse);
            }
            alienSus.HowSus();

        }
        // else if(Input.GetKeyDown("c") && alienStatus.GetForm()!=AlienStatus.Form.duct){
        //     alienStatus.SetForm(AlienStatus.Form.duct);
        //     Debug.Log(alienStatus.GetForm());
        //     alienSus.HowSus();

        // }
        // else if (Input.GetKeyDown("c") && alienStatus.GetForm()==AlienStatus.Form.duct){
        //     alienStatus.SetForm(AlienStatus.Form.alien);
        //     alienSus.HowSus();
        // }
    }

    ///<summary>
    ///Description: If alien is in corpse mode,this is a temporary control for the corpse status<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void TempChangeCorpse(){
        if (Input.GetKeyDown("[1]")){
            alienStatus.SetCorpseStatus(AlienStatus.CorpseStatus.fresh);
            Debug.Log(alienStatus.GetForm());
            Debug.Log(alienStatus.GetCorpseStatus());
            alienSus.HowSus();

        }
        else if (Input.GetKeyDown("[2]")){
            alienStatus.SetCorpseStatus(AlienStatus.CorpseStatus.decomposed);
            Debug.Log(alienStatus.GetForm());
            Debug.Log(alienStatus.GetCorpseStatus());
            alienSus.HowSus();
        }
        else if (Input.GetKeyDown("[3]")){
            alienStatus.SetCorpseStatus(AlienStatus.CorpseStatus.bones);
            Debug.Log(alienStatus.GetForm());
            Debug.Log(alienStatus.GetCorpseStatus());
            alienSus.HowSus();
        }
    }
}
