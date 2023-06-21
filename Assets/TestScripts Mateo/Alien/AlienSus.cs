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
    ///Return: <paramref name="susPercentage"/> between 0 to 100 percent
    ///</summary>
    public float HowSus(){
        float susPercentage=1.0f;

        if (alienStatus.GetForm()==AlienStatus.Form.corpse){
            susPercentage =  SusCorpse();
        }

        else if (alienStatus.GetForm() == AlienStatus.Form.duct){
            susPercentage = 0;
        }
        return susPercentage;
    }

    ///<summary>
    ///Description: Just to clear all the conditions from HowSus() function, the CorpseStatus check is done here <br/>
    ///Input: None<br/>
    ///Return: int <paramref name="susCorpsePercentage"/> between 5 to 70 percent
    ///</summary>
    private float SusCorpse(){
        float susCorpsePercentage = 0.7f;

        if (alienStatus.GetCorpseStatus()==AlienStatus.CorpseStatus.fresh){
            susCorpsePercentage = 0.25f;
        }
        else if (alienStatus.GetCorpseStatus()==AlienStatus.CorpseStatus.decomposed){
            susCorpsePercentage = 0.5f;
        }
        return susCorpsePercentage;
    }
}
