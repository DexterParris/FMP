using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PowerScript : MonoBehaviour
{
    public static float power = 100;
    public static int powerUsage = 1;
    static float powerDrain;
    public TextMeshPro powerText;
    public Sprite level5, level4 , level3 , level2 , level1;
    public GameObject powerIndicator;

    void Start () 
    {
        power = 100;
        powerUsage = 1;
        InvokeRepeating("OutputTime", 1f, 1f);  //1s delay, repeat every 1s
    }

    void OutputTime() 
    {
        powerDrain = powerUsage * 0.2f;
        power -= powerDrain;  
        if(power < 0)
        {
            power = 0;
        }
        powerText.text = Mathf.Floor(power)+"%";
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
        switch (powerUsage)
        {
            case 1:
                powerIndicator.GetComponent<SpriteRenderer>().sprite = level1;
            break;
            
            case 2:
                powerIndicator.GetComponent<SpriteRenderer>().sprite = level2;
            break;

            case 3:
                powerIndicator.GetComponent<SpriteRenderer>().sprite = level3;
            break;

            case 4:
                powerIndicator.GetComponent<SpriteRenderer>().sprite = level4;
            break;

            case 5:
                powerIndicator.GetComponent<SpriteRenderer>().sprite = level5;
            break;
            
            default:
                powerIndicator.GetComponent<SpriteRenderer>().sprite = level5;
            break;
        }
    }

}
