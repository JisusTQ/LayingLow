using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    #region Movement Variables
    [Header("Movement Variables")]
    [Tooltip("Alien movement speed")]
    public float speed;
    private float dir=-1;
    private float prevDir;
    #endregion

    void Start(){
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

        if (dir!=0 && prevDir != dir)
        {
            transform.eulerAngles += new Vector3(0,180,0);
            prevDir=dir;
        }

        Vector3 step = new Vector3(1,0,0) * dir * Time.fixedDeltaTime * speed;
        transform.position += step;

        
    }


}
