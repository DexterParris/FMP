using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ClickNoseScript : MonoBehaviour
{


    public AudioSource honk;
    public AudioClip clownHorn;
    

    //this is a bit of a silly script just for fun 🙂


    public void Clicked()
    {
        honk.PlayOneShot(clownHorn,1);
    }
}
