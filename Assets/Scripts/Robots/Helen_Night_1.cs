using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Helen_Night_1 : MonoBehaviour
{
    int movechance;
    Animator anim;
    bool canMakeScarySound;
    public AudioSource spookysound;

    // Start is called before the first frame update
    void Start()
    {
        canMakeScarySound = true;
        anim = gameObject.GetComponent<Animator>();
        InvokeRepeating("CheckForMove", 1f, 5f);

    }
    
    void CheckForMove()
    {
        movechance = Random.Range(1,21);
        if(movechance <= ActivityLevels.helenActivity && PowerScript.jumpscared == false)
        {
            Move();
        }

    }

    void Update()
    {
        if (anim.GetInteger("Position") == 4 && canMakeScarySound == true && ButtonScript.RLightState == true)
        {
            spookysound.Play();
            canMakeScarySound = false;
        }

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

        }
        else if (anim.GetInteger("Position") == 3)
        {
            anim.SetInteger("Position", 4);
            StartCoroutine(jumpscareCheck());

        }
    }
    IEnumerator jumpscareCheck()
    {
        yield return new WaitForSeconds(Random.Range(5, 8));
        if (ButtonScript.RightDoorState == true)
        {
            anim.SetInteger("Position", 0);
            canMakeScarySound = true;
        }
        else
        {
            PowerScript.jumpscared = true;
            anim.SetInteger("Position", 5);
        }
    }
}
