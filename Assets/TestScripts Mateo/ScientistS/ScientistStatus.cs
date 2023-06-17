using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistStatus : MonoBehaviour
{
    public enum Dir{
        left,
        right,
        none
    }

    public enum Suspicion{
        none,
        alert,
        discovered
    }

    Dir movementDir;
    Suspicion susStatus;

    ///<summary>
    ///Description: Public function to <b>GET</b> the direction status<br/>
    ///Input: None<br/>
    ///Return: MovementDir status
    ///</summary>
    public Dir GetDir()
    {
        return movementDir;
    }

    ///<summary>
    ///Description: Public function to <b>SET</b> the direction status<br/>
    ///Input: 
    ///Return: MovementDir status
    ///</summary>
    public void SetDir(Dir dir)
    {
        movementDir = dir;
    }
}
