using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PhoneCallScript : MonoBehaviour
{
    public AudioSource phonecall;
    public GameObject endCallButton;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait(10));
        anim.SetBool("PhoneCall", true);
        endCallButton.SetActive(true);
        phonecall.Play();
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

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
