using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistDetection : MonoBehaviour
{
    #region Directions
    ScientistMovement movementInfo;
    #endregion

    #region Saw Alien
    bool isSeen;
    bool okSeen;
    #endregion

    #region Alien Info
    GameObject alien;
    AlienSus aliensSuspicion;
    #endregion

    #region How Suspicious
    float suspicion;
    float currentSuspicion;

    ScientistStatus status;
    #endregion

    void Start(){
        suspicion = 0;
        currentSuspicion =0;
        movementInfo = GetComponent<ScientistMovement>();
        alien = GameObject.FindGameObjectWithTag("alien");
        aliensSuspicion = alien.GetComponent<AlienSus>();
        status = GetComponent<ScientistStatus>();
    }
    void FixedUpdate(){
        AlienChangedForm();
        IsAlienSeen();
    }


    ///<summary>
    ///Description:<br/> 
    ///- Comparing the direction of the scientist, with the direction of the alien, we know if it is looking at it and based on the form get how suspicious it is for the scientists, that comparation happens once the scientist sees the alien<br/>
    ///- When the scientist stops looking at the alien, it can compare again, once it crosses its sight
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    void IsAlienSeen(){
        float alienDir = alien.transform.position.x - transform.position.x;
        bool lookingAlienLeft = (alienDir<0 && movementInfo.Dir<0);
        bool lookingAlienRight = (alienDir>0 && movementInfo.Dir>0);
        isSeen = (lookingAlienLeft || lookingAlienRight);
        if (isSeen && !okSeen){
            okSeen = true;
            suspicion = aliensSuspicion.HowSus();
            currentSuspicion = suspicion;
            StatusChange();
            Debug.Log("seen" + suspicion);
        }
        if (!isSeen){
            okSeen = false;
        }
    }

    ///<summary>
    ///Description: It will be weird if the alien changes forms, and the scientist thinks he is a good guy, that's why, if the alien changes form, the <paramref name="okSeen"/> variable, let's the scientist change the suspicion even if it is still loking at the alien<br/>
    ///Input: None<br/>
    ///Return: none
    ///</summary>
    void AlienChangedForm(){
        currentSuspicion = aliensSuspicion.HowSus();
        if (currentSuspicion!=suspicion){
            okSeen = false;
        }
    }

    ///<summary>
    ///Description: The scientist will decide if changes status to alert, and then discovered, based on the suspicion percentage provided by the alien form<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    void StatusChange(){
        if (status.GetSus()== ScientistStatus.Suspicion.none && Random.value<suspicion){
            status.SetSus(ScientistStatus.Suspicion.alert);
        }
        else if (status.GetSus()== ScientistStatus.Suspicion.alert && Random.value<suspicion){
            status.SetSus(ScientistStatus.Suspicion.discovered);
        }

        if (suspicion==1.0f){
            status.SetSus(ScientistStatus.Suspicion.discovered);
        }

        Debug.Log(status.GetSus());
    }

}
