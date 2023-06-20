using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AlienAnimController : MonoBehaviour
{

    AlienStatus alienStatus;
    Animator alienAnimator;

    private void Start(){
        alienStatus= GetComponent<AlienStatus>();
        alienAnimator = GetComponent<Animator>();
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
        }
        else if (alienStatus.GetForm()==AlienStatus.Form.duct){
            //Set whatever variable needed to change animation to duct
        }
        else{
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
}
