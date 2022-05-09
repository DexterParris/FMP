using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bernard_Night_1 : MonoBehaviour
{
    int movechance;
    Animator anim;
    bool cancheckforJumpscare;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        InvokeRepeating("CheckForMove", 1f, 5f);
        cancheckforJumpscare = true;

    }
    
    void CheckForMove()
    {
        movechance = Random.Range(1,21);
        if(movechance <= ActivityLevels.bernardActivity && PowerScript.jumpscared == false)
        {
            Move();
        }

    }
    void Update()
    {

    }

    void Move()
    {
        
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
            StartCoroutine(jumpscareCheck());

        }
    }

    IEnumerator jumpscareCheck()
    {
        if (ButtonScript.LeftDoorState == true)
        {
            yield return new WaitForSeconds(Random.Range(5, 8));
            anim.SetInteger("Position", 0);
            cancheckforJumpscare = true;
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            PowerScript.jumpscared = true;
            anim.SetInteger("Position", 4);
        }
    }
}
