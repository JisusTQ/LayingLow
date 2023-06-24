using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPosses : MonoBehaviour
{
    #region GameObjects and targets

    [SerializeField]
    GameObject alienForm;
    [SerializeField]
    GameObject maleScientist;
    [SerializeField]
    GameObject femaleScientist;
    GameObject[] maleScientists;
    GameObject[] femaleScientists;
    GameObject target;
    #endregion

    AlienStatus alienStatus;

    bool canAttack;
    string maleOrFemale;
    public bool isPossessing;
    // Start is called before the first frame update
    void Start()
    {
        maleScientists = GameObject.FindGameObjectsWithTag("Male");
        femaleScientists = GameObject.FindGameObjectsWithTag("Female");
        alienStatus = GetComponent<AlienStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        FindPosses();
    }



    private void FindPosses(){
        // find a male target
        foreach (GameObject male in maleScientists)
        {
            if (male.GetComponent<GettingAttacked>().canBePossessed){
                target=male;
                maleOrFemale = "male";
                return;
            }
        }

        //find a female target
        foreach (GameObject female in femaleScientists)
        {
            if (female.GetComponent<GettingAttacked>().canBePossessed){
                target=female;
                maleOrFemale = "female";
                return;
            }
        }

        //no target found
        target = null;
    }

    public string Posses(){
        if (target!=null && alienStatus.GetForm()==AlienStatus.Form.alien && !isPossessing){

            #region Scientist sex
            if (maleOrFemale=="male"){
                target.transform.position += new Vector3(30,0,0);
                return maleOrFemale;
            }
            else if(maleOrFemale=="female"){
                target.transform.position += new Vector3(30,0,0);
                return maleOrFemale;
            }
            #endregion

        }
        return null;

    }
}
