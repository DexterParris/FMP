using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Bernard_Night_1 : MonoBehaviour
{
    int movechance;
    Animator anim;
    bool canMakeScarySound;
    public AudioSource spookysound;
    public AudioSource jumpscareSound;
    public Animator NoSignal;

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
        if(movechance <= ActivityLevels.bernardActivity && PowerScript.jumpscared == false && PowerScript.power > 0)
        {
            Move();
        }

    }

    private void Update()
    {
        if (anim.GetInteger("Position") == 3 && canMakeScarySound == true && ButtonScript.LightState == true)
        {
            spookysound.Play();
            canMakeScarySound = false;
        }
    }

    void Move()
    {
        
        if (anim.GetInteger("Position") == 0) 
        {
            if(CCTVScript.currentCAM == "CAM4"||CCTVScript.currentCAM == "CAM2")
            {
                NoSignal.SetTrigger("Active");
            }
            anim.SetInteger("Position", 1);
            
            
        }
        else if(anim.GetInteger("Position") == 1)
        {
            anim.SetInteger("Position", 2);
            if(CCTVScript.currentCAM == "CAM2"||CCTVScript.currentCAM == "CAM5")
            {
                NoSignal.SetTrigger("Active");
            }

        }
        else if (anim.GetInteger("Position") == 2)
        {
            anim.SetInteger("Position", 3);
            if(CCTVScript.currentCAM == "CAM5")
            {
                NoSignal.SetTrigger("Active");
            }
            StartCoroutine(jumpscareCheck());

        }
    }

    IEnumerator jumpscareCheck()
    {
        yield return new WaitForSeconds(Random.Range(6, 8));
        if (ButtonScript.LeftDoorState == true)
        {
            anim.SetInteger("Position", 0);
            if(CCTVScript.currentCAM == "CAM4")
            {
                NoSignal.SetTrigger("Active");
            }
            canMakeScarySound = true;
        }
        else
        {
            jumpscareSound.Play();
            PowerScript.jumpscared = true;
            anim.SetInteger("Position", 4);
        }
    }

}
