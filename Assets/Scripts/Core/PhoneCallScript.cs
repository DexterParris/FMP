using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PhoneCallScript : MonoBehaviour
{
    public AudioSource phonecall;

    public Animator anim;
    public AudioClip Night1;


    // Start is called before the first frame update
    void Start()
    {

        if(PlayerPrefs.GetString("currentNight") == "Night 1")
        {
            phonecall.clip = Night1;
            StartCoroutine(PhoneCall());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator PhoneCall()
    {
        print("hello");
        if(!phonecall.isPlaying)
        {
            yield return new WaitForSeconds(5);
            anim.SetBool("PhoneCall", true);
            phonecall.Play();

        }
        
    }
}
