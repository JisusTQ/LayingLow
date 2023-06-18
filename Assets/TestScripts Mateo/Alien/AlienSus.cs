using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSus : MonoBehaviour
{
    AlienStatus alienStatus;
    private void Start(){
        alienStatus = GetComponent<AlienStatus>();
    }

    ///<summary>
    ///Description: Check the form of the alien and how suspicious the scientist have to be based on that<br/>
    ///If the alien :<br/>
    ///-Is in alien form <paramref name="susPercentage"/> = 100%
    ///-Is in fresh-corpse form <paramref name="susPercentage"/> = 5%
    ///-Is in decomposed-corpse form <paramref name="susPercentage"/> = 25%
    ///-Is in bones-corpse form <paramref name="susPercentage"/> = 80%
    ///Input: None<br/>
    ///Return: <paramref name="susPercentage"/> between 5 to 100 percent
    ///</summary>
    public int HowSus(){
        int susPercentage=100;

        if (alienStatus.GetForm()==AlienStatus.Form.corpse){
            susPercentage =  SusCorpse();
        }

        return susPercentage;
    }

    ///<summary>
    ///Description: Just to clear all the conditions from HowSus() function, the CorpseStatus check is done here <br/>
    ///Input: None<br/>
    ///Return: int <paramref name="susCorpsePercentage"/> between 5 to 70 percent
    ///</summary>
    private int SusCorpse(){
        int susCorpsePercentage = 70;

        if (alienStatus.GetCorpseStatus()==AlienStatus.CorpseStatus.fresh){
            susCorpsePercentage = 5;
        }
        else if (alienStatus.GetCorpseStatus()==AlienStatus.CorpseStatus.decomposed){
            susCorpsePercentage = 25;
        }
        return susCorpsePercentage;
    }
}
