using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistVisualAid : MonoBehaviour
{
    #region Alerts
    GameObject greenAlert;
    GameObject yellowAlert;
    GameObject redAlert;
    #endregion

    #region Status
    ScientistStatus status;
    ScientistStatus.Suspicion prevStatus;
    #endregion

    void Start(){
        status = GetComponent<ScientistStatus>();
        prevStatus = status.GetSus();
        GetVisualAlerts();
        greenAlert.SetActive(true);
        yellowAlert.SetActive(false);
        redAlert.SetActive(false);
    }

    void Update(){
        ControllVisualAlerts();
    }

    #region GetVisualAlerts
    ///<summary>
    ///Description: Finds between the scientist object's childs, the alerts container, and uses <paramref name="GetVisualAlerts2()"/>, to assign the visual aids objects.<br/>
    ///Input: None<br/>
    ///Return: None
    private void GetVisualAlerts(){
        int numberChilds = transform.childCount;
        Transform aidContainer;
        for (int i = 0; i < numberChilds; i++)
        {
            if(transform.GetChild(i).tag == "alertcontainer"){
                aidContainer = transform.GetChild(i);
                GetVisualAlerts2(aidContainer);
                break;
            }
        }
    }

    ///<summary>
    ///Description: Once we have the container transform (<paramref name="aidContainer"/>) based on the tags of its childs, we retrieve the <paramref name="greenAlert"/>, <paramref name="yellowAlert"/>, <paramref name="redAlert"/> objects.<br/>
    ///Input: Transform <paramref name="aidContainer"/><br/>
    ///Return: None<br/>
    ///</summary>
    private void GetVisualAlerts2(Transform aidContainer){
        for (int i = 0; i < aidContainer.childCount; i++)
        {
            if (aidContainer.GetChild(i).tag == "greenalert"){
                greenAlert = aidContainer.GetChild(i).gameObject;
            }
            else if (aidContainer.GetChild(i).tag == "yellowalert"){
                yellowAlert = aidContainer.GetChild(i).gameObject;
            }
            else if (aidContainer.GetChild(i).tag == "redalert"){
                redAlert = aidContainer.GetChild(i).gameObject;
            }
        }
    }
    #endregion
    ///<summary>
    ///Description: Based on the status, it will show a diferent visual aid over the scientists, here those objects will be activated when the status changes<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void ControllVisualAlerts(){
        if (prevStatus!=status.GetSus()){
            switch (status.GetSus())
            {
                case ScientistStatus.Suspicion.alert:
                    greenAlert.SetActive(false);
                    yellowAlert.SetActive(true);
                    redAlert.SetActive(false);
                break;
                case ScientistStatus.Suspicion.discovered:
                    greenAlert.SetActive(false);
                    yellowAlert.SetActive(false);
                    redAlert.SetActive(true);
                break;
            }
            prevStatus=status.GetSus();
        }
    }

}
