using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AlienAnimController : MonoBehaviour
{

    AlienStatus alienStatus;
    Animator alienAnimator;
    bool isAttacking;

    #region AlienForms
    [SerializeField]
    GameObject alienForm;
    [SerializeField]
    GameObject maleScientist;
    [SerializeField]
    GameObject femaleScientist;
    #endregion

    private void Start(){
        alienStatus= GetComponent<AlienStatus>();
        AnimationChange();
    }

    private void Update(){
        AnimationChange();
    }


    ///<summary>
    ///Description: Animation will change based on the status of the alien<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void AnimationChange(){
        if (alienStatus.GetForm()==AlienStatus.Form.alien){
            //Set whatever variable needed to change animation to alien
            #region ActivateObjects
            alienForm.SetActive(true);
            maleScientist.SetActive(false);
            femaleScientist.SetActive(false);
            #endregion
            alienAnimator = alienForm.GetComponent<Animator>();
            Debug.Log("alien form active");
        }
        else if (alienStatus.GetForm()==AlienStatus.Form.duct){
            //Set whatever variable needed to change animation to duct
            #region ActivateObjects
            alienForm.SetActive(false);
            maleScientist.SetActive(false);
            femaleScientist.SetActive(false);
            #endregion
        }
        else{
            #region ActivateObjects
            alienForm.SetActive(false);
            maleScientist.SetActive(true);
            femaleScientist.SetActive(false);
            #endregion
            alienAnimator = maleScientist.GetComponent<Animator>();
            Debug.Log("scientist form active");
            CorpseAnimationChange();
        }
    }

    ///<summary>
    ///Description: If alien is in corpse mode, here the animation will be chosen<br/>
    ///Input: None<br/>
    ///Return: None
    ///<summary/>
    private void CorpseAnimationChange(){
        if (alienStatus.GetCorpseStatus()== AlienStatus.CorpseStatus.fresh){
            //Set whatever variable needed to change animation to fresh corpse
        }
        else if (alienStatus.GetCorpseStatus()== AlienStatus.CorpseStatus.decomposed){
            //Set whatever variable needed to change animation to decomposed corpse
        }
        else{
            //Set whatever variable needed to change animation to bones corpse
        }
    }

    public void AnimationChange(string boolName, bool boolValue){
        alienAnimator.SetBool(boolName, boolValue);
    }




}
