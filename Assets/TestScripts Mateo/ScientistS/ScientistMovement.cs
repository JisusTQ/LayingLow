using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour
{

    #region movement variables
    public int Dir {get; private set;} // direction will change between 1 and -1, it can be called by other scripts, but not set
    int prevDir; // Stores the current dir, to compare when dir changes
    Vector3 oneEightyTurn = new Vector3(0,180,0);
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
    {   //Get Components
        redButton = GameObject.FindGameObjectWithTag("redbutton").GetComponent<Transform>();
        funActivities = GameObject.FindGameObjectsWithTag("funnies");
        status = GetComponent<ScientistStatus>();
        //Set Object Direction
        SetDir();
        //Start task selection coroutine
        StartCoroutine(Choosetask());
    }

    void FixedUpdate()
    {
        TaskExe();
    }


    #region Direction
    ///<summary>
    ///Description: We need to set a direction for the scientists at the beggining, that way, not all the scientist will be facing right if they start with Idle, the object has a 50% to face either way, and starting direction will be stored in <paramref name="prevDir"/><br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void SetDir(){
        Dir = (Random.value<0.5f)?-1:1;
        transform.eulerAngles+=(Dir==1)?Vector3.zero:oneEightyTurn;
        prevDir = Dir;
    }

    ///<summary>
    ///Description: Every time <paramref name="dir"/> changes, a rotation correction will be applied and <paramref name="prevDir"/> will be set to the current <paramref name="dir"/> value <br/>
    ///Input: None
    ///Return: None
    private void NewDir(){
        if (prevDir!=Dir){
            transform.eulerAngles+= oneEightyTurn;
            prevDir = Dir;
        }
    }
    #endregion
    ///<summary>
    ///Description: While scientist are unaware of the alien presence (status.Suspicion = none) they will just walk in the room. If they reach the edge of the room, they will change their direction of movement<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void Walk(){

        Vector3 currentPos = transform.position;

        Vector3 step= new Vector3(walkSpeed,0,0)*Time.fixedDeltaTime;

        if(currentPos.x<10 && currentPos.x>-10){
            transform.position+=step*Dir;
            return;
        }

        Dir *=-1;
        NewDir();

        transform.position +=step*Dir;
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
            float distanceToWork = funActivities[chooseActivitie].transform.position.x - transform.position.x;

           Dir = (distanceToWork<0)? - 1:1;
           NewDir();
            
            Vector3 step = new Vector3(walkSpeed, 0, 0)* Time.fixedDeltaTime * Dir;
            transform.position += step;
        }
        if (transform.position.x <(funActivities[chooseActivitie].transform.position.x+0.1) && transform.position.x >(funActivities[chooseActivitie].transform.position.x-0.1)){
            isWorking=true;
        }
    }

    ///<summary>
    ///Description: If scientists discover the alien, they will run toward the red button to call security running left or right, based on the X distance between the scientist and the button.<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void Run(){
        float distanceToRedButton = redButton.position.x - transform.position.x;

        Dir = (distanceToRedButton<0)?-1:1;
        NewDir();

        Vector3 step = new Vector3(runSpeed, 0, 0)* Time.fixedDeltaTime * Dir;
        transform.position += step;

        if (transform.position.x <(redButton.transform.position.x+0.1) && transform.position.x >(redButton.transform.position.x-0.1)){
            runSpeed=0;
        }
    }

    ///<summary>
    ///Description:<br/>
    ///- Choose a task to do every 15 seconds between the available options<br/>
    ///- Return variables <paramref name="isLookingForJob"/> and <paramref name="isWorking"/> to initial values (true, false)<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    IEnumerator Choosetask(){
        while(true){
            Debug.Log(status.GetTask());
            yield return new WaitForSeconds(5);
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

    ///<summary>
    ///Description: <br/>
    ///- Based on the task randomly selected, execute that task<br/>
    ///- If suspicion status is "discovered", the scientist will run to the red button
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void TaskExe(){
        if (status.GetSus()!= ScientistStatus.Suspicion.discovered){
            if (status.GetTask()==ScientistStatus.Task.walk){
                Walk();
            }
            else if (status.GetTask()==ScientistStatus.Task.work){
                Work();
            }
            return;
        }
        Run();
    }

}
