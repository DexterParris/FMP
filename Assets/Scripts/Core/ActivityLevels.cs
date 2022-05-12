using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityLevels : MonoBehaviour
{
    public static int frankActivity;
    public static int helenActivity;
    public static int bernardActivity;
    public static int orvilleActivity;


    string currentNight;

    // Start is called before the first frame update
    void Start()
    {
        currentNight = PlayerPrefs.GetString("currentNight");
        Debug.Log(currentNight);

        frankActivity = 0;
        helenActivity = 0;
        bernardActivity = 0;
        orvilleActivity = 0;

        if(currentNight == "Night 1")
        {
            StartCoroutine(wait(120));
            bernardActivity = 2;
            StartCoroutine(wait(60));
            helenActivity = 2;
            StartCoroutine(wait(60));
            bernardActivity = 3;
        }
        else if(currentNight == "Night 2")
        {
            StartCoroutine(wait(45));
            helenActivity = 3;
            bernardActivity = 3;
            orvilleActivity = 4;
        }
        else if(currentNight == "Night 3")
        {
            StartCoroutine(wait(25));
            frankActivity = 4;
            helenActivity = 7;
            bernardActivity = 9;
            orvilleActivity = 5;
        }
        else if(currentNight == "Night 4")
        {
            StartCoroutine(wait(10));
            frankActivity = 7;
            helenActivity = 10;
            bernardActivity = 14;
            orvilleActivity = 14;
        }
        else if(currentNight == "Night 5")
        {
            StartCoroutine(wait(10));
            frankActivity = 10;
            helenActivity = 12;
            bernardActivity = 16;
            orvilleActivity = 15;
        }
        else if(currentNight == "Night 6")
        {
            StartCoroutine(wait(10));
            frankActivity = 16;
            helenActivity = 16;
            bernardActivity = 16;
            orvilleActivity = 17;
        }
        else if(currentNight == "Night 7")
        {
            StartCoroutine(wait(15));
            frankActivity = PlayerPrefs.GetInt("frankActivity");
            helenActivity = PlayerPrefs.GetInt("helenActivity");
            bernardActivity = PlayerPrefs.GetInt("bernardActivity");
            orvilleActivity = PlayerPrefs.GetInt("orvilleActivity");
        }
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
