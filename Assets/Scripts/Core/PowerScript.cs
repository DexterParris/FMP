using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;


public class PowerScript : MonoBehaviour
{
    public static float power = 100;
    public static int powerUsage = 1;
    public static bool jumpscared = false;
    static float powerDrain;
    public TextMeshProUGUI powerText;
    public Sprite level5, level4 , level3 , level2 , level1;
    public GameObject powerIndicator;
    public GameObject officelight1,officelight2;
    bool canDoPowerOutage;
    public AudioSource powerShutDownSound;

    void Start () 
    {
        canDoPowerOutage = true;
        jumpscared = false;
        power = 100;
        powerUsage = 1;
        InvokeRepeating("OutputTime", 1f, 0.1f);  //1s delay, repeat every 1s
    }

    void OutputTime() 
    {
        powerDrain = powerUsage * 0.12f;
        power -= powerDrain;  
        if(power < 0)
        {
            power = 0;
        }
        powerText.text = Mathf.Floor(power)+"";
    }

    public static void PowerCheck(string identifier)
    {
        if(identifier == "on")
        {
            powerUsage += 1;
        }
        else if(identifier == "off")
        {
            powerUsage -= 1;
        }
    }

    void Update()
    {
        if(PowerScript.power <= 0 && canDoPowerOutage == true)
        {
            canDoPowerOutage = false;
            powerShutDownSound.Play();
            officelight1.SetActive(false);
            officelight2.SetActive(false);
        }
        if(jumpscared == false)
        {
            switch (powerUsage)
            {
                case 1:
                    powerIndicator.GetComponent<Image>().sprite = level1;
                break;
                
                case 2:
                    powerIndicator.GetComponent<Image>().sprite = level2;
                break;

                case 3:
                    powerIndicator.GetComponent<Image>().sprite = level3;
                break;

                case 4:
                    powerIndicator.GetComponent<Image>().sprite = level4;
                break;

                case 5:
                    powerIndicator.GetComponent<Image>().sprite = level5;
                break;
                
                default:
                    powerIndicator.GetComponent<Image>().sprite = level5;
                break;
            }
        }
        else
        {
            powerIndicator.GetComponent<Image>().sprite = level1;
        }
        
    }

}
