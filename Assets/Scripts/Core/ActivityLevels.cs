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
            StartCoroutine(Night1());
        }
        else if(currentNight == "Night 2")
        {
            StartCoroutine(Night2());
        }
        else if(currentNight == "Night 3")
        {
            StartCoroutine(Night3());
        }
        else if(currentNight == "Night 4")
        {
            StartCoroutine(Night4());
        }
        else if(currentNight == "Night 5")
        {
            StartCoroutine(Night5());
        }
        else if(currentNight == "Night 6")
        {
            StartCoroutine(Night6());
        }
        else if(currentNight == "Custom Night")
        {
            StartCoroutine(CustomNight());
        }
    }

    IEnumerator Night1()
    {
        yield return new WaitForSeconds(120);
        bernardActivity = 2;
        yield return new WaitForSeconds(60);
        helenActivity = 2;
        yield return new WaitForSeconds(60);
        bernardActivity = 3;
    }
    IEnumerator Night2()
    {
        yield return new WaitForSeconds(45);
        helenActivity = 2;
        bernardActivity = 1;
        yield return new WaitForSeconds(75);
        orvilleActivity = 2;
    }
    IEnumerator Night3()
    {
        yield return new WaitForSeconds(45);
        frankActivity = 2;
        helenActivity = 3;
        bernardActivity = 3;
        orvilleActivity = 3;
    }

    IEnumerator Night4()
    {
        yield return new WaitForSeconds(15);
        frankActivity = 3;
        helenActivity = 4;
        bernardActivity = 5;
        orvilleActivity = 6;
    }

    IEnumerator Night5()
    {
        yield return new WaitForSeconds(15);
        frankActivity = 5;
        helenActivity = 5;
        bernardActivity = 5;
        orvilleActivity = 7;
    }

    IEnumerator Night6()
    {
        yield return new WaitForSeconds(150);
        frankActivity = 8;
        helenActivity = 7;
        bernardActivity = 9;
        orvilleActivity = 15;
    }

    IEnumerator CustomNight()
    {
        yield return new WaitForSeconds(15);
        frankActivity = PlayerPrefs.GetInt("frankActivity");
        helenActivity = PlayerPrefs.GetInt("helenActivity");
        bernardActivity = PlayerPrefs.GetInt("bernardActivity");
        orvilleActivity = PlayerPrefs.GetInt("orvilleActivity");
    }


}
