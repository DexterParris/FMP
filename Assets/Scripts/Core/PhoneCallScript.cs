using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PhoneCallScript : MonoBehaviour
{
    public AudioSource phonecall;
    public GameObject endCallButton;
    public Animator anim;
    public AudioClip Night1,Night2,Night3,Night4,Night5,Night6,CustomNight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PhoneCall()); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!phonecall.isPlaying)
        {
            StopCall();
        }
    }

    public void StopCall()
    {
        phonecall.Stop();
        anim.SetBool("PhoneCall", false);
        endCallButton.SetActive(false);
    }

    IEnumerator PhoneCall()
    {
        print("hello");
        if(!phonecall.isPlaying)
        {
            yield return new WaitForSeconds(5);
            anim.SetBool("PhoneCall", true);
            phonecall.Play();
            yield return new WaitForSeconds(7);
            endCallButton.SetActive(true);
        }
        
    }
}
