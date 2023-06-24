using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    #region Movement Variables
    [Header("Movement Variables")]
    [Tooltip("Alien movement speed")]
    public float speed;
    private float dir=1;
    private float prevDir;
    #endregion

    AlienAnimController animController;
    CanAttack isAttacking;
    AlienStatus alienStatus;
    [SerializeField] GameObject camara;

    void Start(){
        isAttacking = GetComponent<CanAttack>();
        animController=GetComponent<AlienAnimController>();
        alienStatus = GetComponent<AlienStatus>();
        prevDir= dir;
    }

    private void FixedUpdate(){

        Walk();
    }


    ///<summary>
    ///Description: Use A-D or ◄ ► to move the alien character to the left or the right
    ///Input: None
    ///Return: None
    ///</summary>
    private void Walk (){
        dir = Input.GetAxisRaw("Horizontal");

        if (dir!=0 && prevDir != dir && !isAttacking.isAttacking&& alienStatus.GetForm()!=AlienStatus.Form.duct)
        {
            transform.eulerAngles += new Vector3(0,180,0);
            prevDir=dir;
            camara.transform.eulerAngles -= new Vector3(0, 180, 0);
        }
        if (dir==0){
            animController.AnimationChange("isWalking", false);
        }
        else{
            animController.AnimationChange("isWalking", true);
        }

        if (!isAttacking.isAttacking && alienStatus.GetForm()!=AlienStatus.Form.duct){
            Vector3 step = new Vector3(1,0,0) * dir * Time.fixedDeltaTime * speed;
            transform.position += step;
        }
    }


}
