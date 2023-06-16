using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour
{

    #region movement variables
    int direction; // direction will change between 1 and -1
    public float speed; // how fast the object will move in the screen
    #endregion

    #region bools
    bool isEdge; // the character is in the edge of the screen
    // bool 
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        RandomStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
    }

    ///<summary>
    ///Description: While scientist are unaware of the alien presence they will just walk in the room.<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void Walk(){

        Vector3 currentPos = transform.position;

        Vector3 step= new Vector3(speed,0,0)*Time.fixedDeltaTime;

        if(currentPos.x<10 && currentPos.x>-10){
            transform.position+=step*direction;
            return;
        }

        direction *=-1;

        transform.position +=step*direction;




    }

    ///<summary>
    ///Description: Called at the Start(), here, all the needed data for movement and behavior will have a random set up<br/>
    ///Input: None<br/>
    ///Return: None
    ///</summary>
    private void RandomStart(){
        direction = Random.Range(-1, 2);
    }
}
