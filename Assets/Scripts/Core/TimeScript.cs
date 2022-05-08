using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public Animator anim;
    public static int currentTime;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI nightText;
    // Start is called before the first frame update
    void Start()
    {
        nightText.text = PlayerPrefs.GetString("currentNight");
        currentTime = 0;
        InvokeRepeating("ChangeTime", 60f, 60f);
    }

    void Update()
    {
        if(PowerScript.jumpscared == true)
        {
            wait(2f);
            StartCoroutine(ChangeScene());
        }
    }

    public void ChangeTime()
    {
        if(currentTime == 5)
        {
            currentTime = 6;
            timeText.text = ("0"+currentTime+":AM");
            if(PlayerPrefs.GetString("currentNight")=="Night 1")
            {
                PlayerPrefs.SetString("currentNight","Night 2");
                StartCoroutine(ChangeScene());
            }
            else if(PlayerPrefs.GetString("currentNight")=="Night 2")
            {
                PlayerPrefs.SetString("currentNight","Night 3");
                StartCoroutine(ChangeScene());
            }
            else if(PlayerPrefs.GetString("currentNight")=="Night 3")
            {
                PlayerPrefs.SetString("currentNight","Night 4");
                StartCoroutine(ChangeScene());
            }
            else if(PlayerPrefs.GetString("currentNight")=="Night 4")
            {
                PlayerPrefs.SetString("currentNight","Night 5");
                StartCoroutine(ChangeScene());
            }
            else if(PlayerPrefs.GetString("currentNight")=="Night 5")
            {
                PlayerPrefs.SetString("currentNight","Night 6");
                StartCoroutine(ChangeScene());
            }
            else if(PlayerPrefs.GetString("currentNight")=="Night 6")
            {
                PlayerPrefs.SetString("currentNight","Night 7");
                StartCoroutine(ChangeScene());
            }
            else if(PlayerPrefs.GetString("currentNight")=="Night 7")
            {
                PlayerPrefs.SetString("currentNight","Night 7");
                StartCoroutine(ChangeScene());
            }
            
        }
        else
        {
            currentTime += 1;
            timeText.text = ("0"+currentTime+":AM");
        }
        
    }


    IEnumerator ChangeScene()
    {
        anim.SetTrigger("ToBlack");
        
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
