using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStatus : MonoBehaviour
{
    public enum Form{
        alien,
        corpse,
        duct
    }

    public enum CorpseStatus{
        fresh,
        decomposed, 
        bones
    }

    Form currentAlienForm;
    CorpseStatus currentCorpseStatus;

    #region Alien Form
    ///<summary>
    ///Description: Public function to <b>GET</b> the current Alien form<br/>
    ///Input: None<br/>
    ///Return: Alien Form status
    ///</summary>
    public Form GetForm()
    {
        return currentAlienForm;
    }

    ///<summary>
    ///Description: Public function to <b>SET</b> the Alien Form status to <paramref name="alienForm"/> provided as parameter <br/>
    ///Input: <paramref name="alienForm"/><br/>
    ///Return: None
    ///</summary>
    public void SetForm(Form alienForm)
    {
        currentAlienForm = alienForm;
    }
    #endregion

    #region Corpse Status
    ///<summary>
    ///Description: Public function to <b>GET</b> the current Corpse Status<br/>
    ///Input: None<br/>
    ///Return: Corpse status
    ///</summary>
    public CorpseStatus GetCorpseStatus()
    {
        return currentCorpseStatus;
    }

    ///<summary>
    ///Description: Public function to <b>SET</b> the Corpse Status to <paramref name="corpseStatus"/> provided as parameter <br/>
    ///Input: <paramref name="corpseStatus"/><br/>
    ///Return: None
    ///</summary>
    public void SetCorpseStatus(CorpseStatus corpseStatus)
    {
        currentCorpseStatus = corpseStatus;
    }
    #endregion

}
