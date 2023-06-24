using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingAttacked : MonoBehaviour
{
    #region Alien Room
    GameObject alienPos;
    WhereAmI alienRoom;
    #endregion

    public bool canBeAttacked;
    public bool canBePossessed;
    public bool beingAttacked;
    WhereAmI myRoom;

    CanAttack alienAttack;

    ScientistMovement scientistDead;
    // Start is called before the first frame update
    void Start()
    {
        scientistDead = GetComponent<ScientistMovement>();
        alienPos = GameObject.FindGameObjectWithTag("alien");
        alienRoom = alienPos.GetComponent<WhereAmI>();
        alienAttack = alienPos.GetComponent<CanAttack>();
        myRoom = GetComponent<WhereAmI>();
    }

    // Update is called once per frame
    void Update()
    {
        AlienNear();
        AlienIsAttackingMe();
    }

    private void AlienNear(){
        float alienX = alienPos.transform.position.x;
        float myX = transform.position.x;

        if (myRoom.room == alienRoom.room){
            if (alienX < myX+0.3f && alienX > myX-0.3 && !scientistDead.isDead){
                canBeAttacked = true;

            }
            else{
                canBeAttacked = false;
            }

            if (alienX<myX+0.4f && alienX>myX-0.4f && scientistDead.isDead){
                canBePossessed = true;
            }
            else{
                canBePossessed =false;
            }
        }
    }

    private void AlienIsAttackingMe(){
        if (alienAttack.isAttacking&& canBeAttacked){
            beingAttacked = true;
        }
    }

}
