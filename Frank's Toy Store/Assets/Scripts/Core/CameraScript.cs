using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector2 mouse;

    public Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.mousePosition.x < Screen.width * 0.2)
        {
            anim.SetInteger("Position",0);
        }
        else if(Input.mousePosition.x > Screen.width * 0.8)
        {
            anim.SetInteger("Position",2);
        }
        else
        {
            anim.SetInteger("Position",1);
        }
        
    }
}
