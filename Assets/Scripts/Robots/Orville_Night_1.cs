using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orville_Night_1 : MonoBehaviour
{
    int movechance;
    Animator anim;
    bool cancheckforJumpscare;
    bool cancheckforCamera;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        InvokeRepeating("CheckForMove", 1f, 5f);
        cancheckforJumpscare = true;
        cancheckforCamera = true;
    }

    void CheckForMove()
    {
        movechance = Random.Range(1, 21);
        if (movechance <= ActivityLevels.orvilleActivity && PowerScript.jumpscared == false)
        {
            Move();
        }

    }

    void Update()
    {
        if(anim.GetInteger("Position") < 3 && cancheckforCamera && CCTVScript.currentCAM == "CAM9")
        {
            StartCoroutine(ResetPos());
            cancheckforCamera = false;
        }
        if (cancheckforJumpscare && anim.GetInteger("Position") == 4)
        {
            StartCoroutine(jumpscareCheck());
            cancheckforJumpscare = false;

        }
    }

    void Move()
    {

        if (anim.GetInteger("Position") == 0)
        {
            anim.SetInteger("Position", 1);

        }
        else if (anim.GetInteger("Position") == 1)
        {
            anim.SetInteger("Position", 2);

        }
        else if (anim.GetInteger("Position") == 2)
        {
            StartCoroutine(run());

        }

    }
    IEnumerator jumpscareCheck()
    {
        yield return new WaitForSeconds(Random.Range(10, 14));
        if (ButtonScript.LeftDoorState == true)
        {
            anim.SetInteger("Position", 0);
            cancheckforJumpscare = true;
        }
        else
        {
            PowerScript.jumpscared = true;
            anim.SetInteger("Position", 5);
        }
    }

    IEnumerator run()
    {
        anim.SetInteger("Position", 3);
        yield return new WaitForSeconds(1.5f);
        anim.SetInteger("Position", 4);
    }

    IEnumerator ResetPos() 
    {
        yield return new WaitForSeconds(3);
        anim.SetInteger("Position", 0);
        cancheckforCamera = true;
    }
}
