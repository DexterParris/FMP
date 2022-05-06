using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public static int currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 12;
        InvokeRepeating("ChangeTime", 90f, 89f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTime()
    {
        if(currentTime == 12)
        {
            currentTime = 01;
        }
        else if(currentTime == 6)
        {
            currentTime = 06;
            
        }
        else
        {
            currentTime += 01;
        }
        
    }
}
