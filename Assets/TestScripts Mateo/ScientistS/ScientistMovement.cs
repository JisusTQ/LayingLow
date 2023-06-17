using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour
{

    #region movement variables
    int direction; // direction will change between 1 and -1
    [Header("Movement Variables")]
    [Tooltip("How fast the object will walk")]
    public float walkSpeed; // how fast the object will walk
    [Tooltip("How fast the object will run")]
    public float runSpeed; // how fast the objct will run
    #endregion

    #region bools
    bool isEdge; // the character is in the edge of the screen
    bool isLookingForJob = true; //the character is choosing where to work 
    bool isWorking; // The scientist reached the machine
    #endregion

    #region ints
    int chooseActivitie = 0;// index of the object where the character will "work" on
    #endregion
   #region Screen Objects
    
    GameObject[] funActivities; //stores the positions of every activity the scientist can perform if they are unaware of danger and decide to work
    Transform redButton; // if the scientist discovers the alien, here it will call security.

    #endregion

    # region status
    ScientistStatus status;
    # endregion
    
    
    void Start()
    {   
        redButton = GameObject.FindGameObjectWithTag("redbutton").GetComponent<Transform>();
        funActivities = GameObject.FindGameObjectsWithTag("funnies");
        status = GetComponent<ScientistStatus>();
        StartCoroutine(Choosetask());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TaskExe();
    }

    ///<summary>
    ///Description: While scientist are unaware of the alien presence (status.Suspicion = none) they will just walk in the room. If they reach the edge of the room, they will change their direction of movement<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void Walk(){

        Vector3 currentPos = transform.position;

        Vector3 step= new Vector3(walkSpeed,0,0)*Time.fixedDeltaTime;

        if(currentPos.x<10 && currentPos.x>-10){
            transform.position+=step*direction;
            return;
        }

        direction *=-1;

        transform.position +=step*direction;
    }

    ///<summary>
    ///Description: If scientists discover the alien, they will run toward the red button to call security running left or right, based on the X distance between the scientist and the button.<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void Run(){
        int redButtonDir;
        float distanceToRedButton = redButton.position.x - transform.position.x;

        redButtonDir = (distanceToRedButton<0)?-1:1;

        Vector3 step = new Vector3(runSpeed, 0, 0)* Time.fixedDeltaTime * redButtonDir;
        transform.position += step;
    }

    ///<summary>
    /// Description: If Work, gets selected as the task status, the scientist will choose a random object to work on, they will walk to it based on the position and do their bussiness<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void Work(){
        
        if(isLookingForJob){
            chooseActivitie = Random.Range(0, funActivities.Length);
            isLookingForJob=false;
        }

        if (!isWorking)
        {
            int workDir;
            float distanceToWork = funActivities[chooseActivitie].transform.position.x - transform.position.x;

            workDir = (distanceToWork<0)? - 1:1;
            
            Vector3 step = new Vector3(walkSpeed, 0, 0)* Time.fixedDeltaTime * workDir;
            transform.position += step;
        }
        if (transform.position.x <(funActivities[chooseActivitie].transform.position.x+0.1) && transform.position.x >(funActivities[chooseActivitie].transform.position.x-0.1)){
            isWorking=true;
        }
    }

    IEnumerator Choosetask(){
        while(true){
            Debug.Log(status.GetTask());
            direction = (status.GetDir()==ScientistStatus.Dir.right)?1:-1;
            yield return new WaitForSeconds(15);
            int randTask = Random.Range(0,3);
            switch (randTask)
            {
                case 0:
                    status.SetTask(ScientistStatus.Task.walk);
                break;
                
                case 1:
                    status.SetTask(ScientistStatus.Task.work);
                break;
                
                case 2:
                    status.SetTask(ScientistStatus.Task.idle);
                break;
            }
            isLookingForJob = true;
            isWorking = false;
            
        }
    }

    private void TaskExe(){
        if (status.GetTask()==ScientistStatus.Task.walk){
            Walk();
        }
        else if (status.GetTask()==ScientistStatus.Task.work){
            Work();
        }
    }

}
