using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVScript : MonoBehaviour
{
    public GameObject CAM1,CAM2,CAM3,CAM4,CAM5,CAM6,CAM7,CAM8,CAM9;
    public Camera mainCam;
    public static string currentCAM;
    public GameObject map;
    public static bool camsOpen; 

    // Start is called before the first frame update
    void Start()
    {
        currentCAM = "CAM1";
        camsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCams()
    {
        if(camsOpen == false)
        {
            camsOpen = true;
            mainCam.enabled = false;
            map.SetActive(true);
            StartCoroutine(ResetCams());
            if(currentCAM == "CAM1")
            {
                CAM01();
            }
            else if(currentCAM == "CAM2")
            {
                CAM02();
            }
            else if(currentCAM == "CAM3")
            {
                CAM03();
            }
            else if(currentCAM == "CAM4")
            {
                CAM04();
            }
            else if(currentCAM == "CAM5")
            {
                CAM05();
            }
            else if(currentCAM == "CAM6")
            {
                CAM06();
            }
            else if(currentCAM == "CAM7")
            {
                CAM07();
            }
            else if(currentCAM == "CAM8")
            {
                CAM08();
            }
            else if(currentCAM == "CAM9")
            {
                CAM09();
            }
        }
        else
        {
            camsOpen = false;
            map.SetActive(false);
            StartCoroutine(ResetCams());
            mainCam.enabled = true;
        }
        
    }

    IEnumerator ResetCams()
    {
        CAM1.SetActive(false);
        CAM2.SetActive(false);
        CAM3.SetActive(false);
        CAM4.SetActive(false);
        CAM5.SetActive(false);
        CAM6.SetActive(false);
        CAM7.SetActive(false);
        CAM8.SetActive(false);
        CAM9.SetActive(false);
        yield return null;
    }

    public void CAM01()
    {
        StartCoroutine(ResetCams());
        CAM1.SetActive(true);
        currentCAM = "CAM01";
    }

    public void CAM02()
    {
        StartCoroutine(ResetCams());
        CAM2.SetActive(true);
        currentCAM = "CAM2";
    }
    public void CAM03()
    {
        StartCoroutine(ResetCams());
        CAM3.SetActive(true);
        currentCAM = "CAM3";
    }
    public void CAM04()
    {
        StartCoroutine(ResetCams());
        CAM4.SetActive(true);
        currentCAM = "CAM4";
    }
    public void CAM05()
    {
        StartCoroutine(ResetCams());
        CAM5.SetActive(true);
        currentCAM = "CAM5";
    }
    public void CAM06()
    {
        StartCoroutine(ResetCams());
        CAM6.SetActive(true);
        currentCAM = "CAM6";
    }
    public void CAM07()
    {
        StartCoroutine(ResetCams());
        CAM7.SetActive(true);
        currentCAM = "CAM7";
    }
    public void CAM08()
    {
        StartCoroutine(ResetCams());
        CAM8.SetActive(true);
        currentCAM = "CAM8";
    }
    public void CAM09()
    {
        StartCoroutine(ResetCams());
        CAM9.SetActive(true);
        currentCAM = "CAM9";
    }
    

}
