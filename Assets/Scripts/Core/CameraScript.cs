using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector2 mouse;

    public Animator anim;
    public static bool PowerOutage;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }



    // Update is called once per frame
    void LateUpdate()
    {
        if(PowerScript.jumpscared == true)
        {
            anim.SetInteger("Position", 1);
            
        }
        else if(PowerOutage == true && PowerScript.jumpscared == false) 
        {
            anim.SetInteger("Position", 0);
        }
        else
        {
            if (Input.mousePosition.x < Screen.width * 0.2)
            {
                anim.SetInteger("Position", 0);
            }
            else if (Input.mousePosition.x > Screen.width * 0.8)
            {
                anim.SetInteger("Position", 2);
            }
            else
            {
                anim.SetInteger("Position", 1);
            }
        }
   
    }
}
