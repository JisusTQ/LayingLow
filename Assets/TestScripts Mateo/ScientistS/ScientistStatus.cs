using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistStatus : MonoBehaviour
{
    public enum Dir{
        left,
        right
    }

    public enum Suspicion{
        none,
        alert,
        discovered
    }

    public enum Task{
        walk,
        work,
        idle
    }

    public Dir movementDir;
    Suspicion susStatus;
    Task taskStatus;

    public void Start(){
        RandomStart();
    }

    #region Direction
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
    ///Description: Public function to <b>SET</b> the direction status to <paramref name="dir"/> provided as parameter <br/>
    ///Input: <paramref name="dir"/><br/>
    ///Return: None
    ///</summary>
    public void SetDir(Dir dir)
    {
        movementDir = dir;
    }
    #endregion

    #region Suspicion
    ///<summary>
    ///Description: Public function to <b>GET</b> the Suspicion status<br/>
    ///Input: None<br/>
    ///Return: susStatus status
    ///</summary>
    public Suspicion GetSus()
    {
        return susStatus;
    }

    ///<summary>
    ///Description: Public function to <b>SET</b> the Suspicion status to <paramref name="sus"/> provided as parameter <br/>
    ///Input: <paramref name="sus"/><br/>
    ///Return: None
    ///</summary>
    public void SetSus(Suspicion sus)
    {
        susStatus = sus;
    }
    #endregion

    #region Task
    ///<summary>
    ///Description: Public function to <b>GET</b> the task status<br/>
    ///Input: None<br/>
    ///Return: taskStatus status
    ///</summary>
    public Task GetTask()
    {
        return taskStatus;
    }

    ///<summary>
    ///Description: Public function to <b>SET</b> the task status to <paramref name="task"/> provided as parameter<br/>
    ///Input: <paramref name="task"/><br/>
    ///Return: None
    ///</summary>
    public void SetTask(Task task)
    {
        taskStatus = task;
    }
    #endregion

    ///<summary>
    ///Description: Called at the Start(), here, all the needed data for movement and behavior will have a random set up.<br/>
    ///- Direction and task will be randomly choosen<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void RandomStart(){
        int randDir = Random.Range(0,2);
        int randTask = Random.Range(0,3);

        switch (randDir)
        {
            case 0:
                SetDir(Dir.left);
            break;

            case 1:
                SetDir(Dir.right);
            break;
        }

        switch (randTask)
        {
            case 0:
                SetTask(Task.walk);
            break;
            
            case 1:
                SetTask(Task.work);
            break;
            
            case 2:
                SetTask(Task.idle);
            break;
        }
        
    }

}
