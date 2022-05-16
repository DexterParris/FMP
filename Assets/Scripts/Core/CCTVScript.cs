using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class CCTVScript : MonoBehaviour
{
    public GameObject CAM1,CAM2,CAM3,CAM4,CAM5,CAM6,CAM7,CAM8,CAM9;
    public Camera mainCam;
    public static string currentCAM;
    public GameObject map;
    public static bool camsOpen; 
    public TextMeshProUGUI cameraButton;
    public AudioSource buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        currentCAM = "CAM1";
        camsOpen = false;
    }

    void Update()
    {
        if (PowerScript.jumpscared == true || PowerScript.power <= 0)
        {
            camsOpen = false;
            cameraButton.text = ">>>Open Cameras<<<";
            cameraButton.text = ">>>  Disabled  <<<";
            map.SetActive(false);
            ResetCams();
        }
        
    }

    public void ToggleCams()
    {
        if(camsOpen == false && PowerScript.jumpscared == false)
        {
            cameraButton.text = ">>>Close Cameras<<<";
            camsOpen = true;
            map.SetActive(true);
            ResetCams();
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
        else if(TimeScript.currentTime == 6)
        {
            camsOpen = false;
            cameraButton.text = ">>>Open Cameras<<<";
            map.SetActive(false);
            ResetCams();
        }
        else
        {
            camsOpen = false;
            cameraButton.text = ">>>Open Cameras<<<";
            map.SetActive(false);
            ResetCams();
            
        }
        
    }


    void ResetCams()
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
        
    }

    public void CAM01()
    {
        buttonClick.Play();
        ResetCams();
        CAM1.SetActive(true);
        currentCAM = "CAM1";
    }

    public void CAM02()
    {
        buttonClick.Play();
        ResetCams();
        CAM2.SetActive(true);
        currentCAM = "CAM2";
    }
    public void CAM03()
    {
        buttonClick.Play();
        ResetCams();
        CAM3.SetActive(true);
        currentCAM = "CAM3";
    }
    public void CAM04()
    {
        buttonClick.Play();
        ResetCams();
        CAM4.SetActive(true);
        currentCAM = "CAM4";
    }
    public void CAM05()
    {
        buttonClick.Play();
        ResetCams();
        CAM5.SetActive(true);
        currentCAM = "CAM5";
    }
    public void CAM06()
    {
        buttonClick.Play();
        ResetCams();
        CAM6.SetActive(true);
        currentCAM = "CAM6";
    }
    public void CAM07()
    {
        buttonClick.Play();
        ResetCams();
        CAM7.SetActive(true);
        currentCAM = "CAM7";
    }
    public void CAM08()
    {
        buttonClick.Play();
        ResetCams();
        CAM8.SetActive(true);
        currentCAM = "CAM8";
    }
    public void CAM09()
    {
        buttonClick.Play();
        ResetCams();
        CAM9.SetActive(true);
        currentCAM = "CAM9";
    }
    

}
