using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Frank_Night_1 : MonoBehaviour
{
    int movechance;
    Animator anim;
    public int randomnum;
    bool canDoPowerOutage;
    public AudioSource outageSound;
    public GameObject frankLight;
    public AudioSource laugh;
    public AudioSource jumpscareSound;
    public Animator NoSignal;

    // Start is called before the first frame update
    void Start()
    {
        canDoPowerOutage = true;
        anim = gameObject.GetComponent<Animator>();
        InvokeRepeating("CheckForMove", 1f, 5f);

    }

    void Update()
    {
        if(PowerScript.power <= 0 && canDoPowerOutage == true)
        {
            print("look at me");
            canDoPowerOutage = false;
            StartCoroutine(FrankPowerOutage());

        }
    }
    
    void CheckForMove()
    {
        movechance = Random.Range(1,21);
        if(movechance <= ActivityLevels.frankActivity && PowerScript.jumpscared == false && PowerScript.power > 0)
        {
            Move();
        }

    }
    
    void Move()
    {
        randomnum = Random.Range(1, 3);
        anim.SetInteger("RandomNumber", randomnum);

        if (anim.GetInteger("Position") <= 5) 
        {
            laugh.Play();
        }
        
        if (anim.GetInteger("Position") == 0) 
        {
            if(CCTVScript.currentCAM == "CAM1"||CCTVScript.currentCAM == "CAM2")
            {
                NoSignal.SetTrigger("Active");
            }
            anim.SetInteger("Position", 1);
            
        }
        else if(anim.GetInteger("Position") == 1)
        {
            if(CCTVScript.currentCAM == "CAM2"||CCTVScript.currentCAM == "CAM3")
            {
                NoSignal.SetTrigger("Active");
            }
            anim.SetInteger("Position", 2);

        }
        else if (anim.GetInteger("Position") == 2)
        {
            if(CCTVScript.currentCAM == "CAM3"||CCTVScript.currentCAM == "CAM2")
            {
                NoSignal.SetTrigger("Active");
            }
            anim.SetInteger("Position", 3);

        }
        else if (anim.GetInteger("Position") == 3)
        {
            if(CCTVScript.currentCAM == "CAM2"||CCTVScript.currentCAM == "CAM6")
            {
                NoSignal.SetTrigger("Active");
            }
            anim.SetInteger("Position", 4);

        }
        else if (anim.GetInteger("Position") == 4)
        {
            if(CCTVScript.currentCAM == "CAM6"||CCTVScript.currentCAM == "CAM8")
            {
                NoSignal.SetTrigger("Active");
            }
            anim.SetInteger("Position", 5);

        }
        else if (anim.GetInteger("Position") == 5)
        {
            if(ButtonScript.RightDoorState == true)
            {
                if(CCTVScript.currentCAM == "CAM1"|| CCTVScript.currentCAM == "CAM8")
                {
                    NoSignal.SetTrigger("Active");
                }
                anim.SetInteger("Position",0);
            }
            else
            {
                jumpscareSound.Play();
                PowerScript.jumpscared = true;
                anim.SetInteger("Position", 6);
            }
            

        }

    }

    IEnumerator FrankPowerOutage()
    {
        yield return new WaitForSeconds(6);
        frankLight.SetActive(true);
        anim.SetInteger("Position",7);
        outageSound.Play();
        yield return new WaitForSeconds(27);
        jumpscareSound.Play();
        PowerScript.jumpscared = true;
        anim.SetInteger("Position",6);

    }

}
