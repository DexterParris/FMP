using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Frank_Night_1 : MonoBehaviour
{
    int movechance;
    Animator anim;
    public int randomnum;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        InvokeRepeating("CheckForMove", 1f, 5f);

    }
    
    void CheckForMove()
    {
        movechance = Random.Range(1,21);
        if(movechance <= ActivityLevels.frankActivity && PowerScript.jumpscared == false)
        {
            Move();
        }

    }
    
    void Move()
    {
        randomnum = Random.Range(1, 3);
        anim.SetInteger("RandomNumber", randomnum);
        
        if (anim.GetInteger("Position") == 0) 
        {
            anim.SetInteger("Position", 1);
            
        }
        else if(anim.GetInteger("Position") == 1)
        {
            anim.SetInteger("Position", 2);

        }
        else if (anim.GetInteger("Position") == 2)
        {
            anim.SetInteger("Position", 3);

        }
        else if (anim.GetInteger("Position") == 3)
        {
            anim.SetInteger("Position", 4);

        }
        else if (anim.GetInteger("Position") == 4)
        {
            anim.SetInteger("Position", 5);

        }
        else if (anim.GetInteger("Position") == 5)
        {
            if(ButtonScript.RightDoorState == true)
            {
                anim.SetInteger("Position",0);
            }
            else
            {
                PowerScript.jumpscared = true;
                anim.SetInteger("Position", 6);
            }
            

        }
    }
}
