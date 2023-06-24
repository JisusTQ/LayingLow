using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttack : MonoBehaviour
{
    #region GameObjects and targets
    GameObject[] maleScientists;
    GameObject[] femaleScientists;
    GameObject target;
    #endregion
    [SerializeField]
    GameObject alienObj;
    Animator alienAnimator;
    AlienStatus alienStatus;

    bool canAttack;
    public bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        maleScientists = GameObject.FindGameObjectsWithTag("Male");
        femaleScientists = GameObject.FindGameObjectsWithTag("Female");
        alienStatus = GetComponent<AlienStatus>();
        alienAnimator = alienObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FindToAttack();
        Attack();
    }

    // z attack, x take body, c vent.

    private void FindToAttack(){

        // find a male target
        foreach (GameObject male in maleScientists)
        {
            if (male.GetComponent<GettingAttacked>().canBeAttacked){
                target=male;
                return;
            }
        }
        //find a female target
        foreach (GameObject female in femaleScientists)
        {
            if (female.GetComponent<GettingAttacked>().canBeAttacked){
                target=female;
                return;
            }
        }
        //no target found
        target = null;
    }

    private void Attack(){
        if (target!=null && Input.GetKeyDown("z") && alienStatus.GetForm()==AlienStatus.Form.alien && !isAttacking){
            alienAnimator.SetBool("isAttacking", true);
            isAttacking = true;
            StartCoroutine(RunAnimation());
        }
    }

    IEnumerator RunAnimation(){
        yield return new WaitForSeconds(2f);
        isAttacking=false;
        alienAnimator.SetBool("isAttacking", false);

    }
}
