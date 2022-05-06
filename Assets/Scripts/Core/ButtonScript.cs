using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Light light1;
    public Light light2;

    public Material White,Purple,Green,Red;

    public GameObject rightlightbutton;
    public GameObject leftlightbutton;
    public GameObject rightdoorbutton;
    public GameObject leftdoorbutton;

    public GameObject LDoor,RDoor;

    Animator leftanim;
    Animator rightanim;

    public static bool LeftDoorState,RightDoorState;

    Light Leftlight;
    Light Rightlight;

    public bool LightState;
    public bool RLightState;

    bool camState;
    const bool OFF = false;
    const bool ON = true;

    public AudioSource Buzz,Slam;

    string buttonName;


    // Start is called before the first frame update
    void Start()
    {
        Leftlight = light1.GetComponent<Light>();
        Rightlight = light2.GetComponent<Light>();

        Leftlight.enabled = false;
        Rightlight.enabled = false;

        leftanim = LDoor.GetComponent<Animator>();
        rightanim = RDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {   
        camState = CCTVScript.camsOpen;
        leftanim.SetFloat("Power", PowerScript.power);
        rightanim.SetFloat("Power", PowerScript.power);
        LeftDoorState = leftanim.GetBool("Closed");
        RightDoorState = rightanim.GetBool("Closed");

        if(PowerScript.power == 0)
        {
            PowerOutage();
        }
        
        if (Input.GetMouseButtonDown(0) && camState == false)
        {
            print(camState);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.00f) && hit.transform != null)
            {
                buttonName = hit.transform.gameObject.name;

                if(buttonName == "LDoorButton")
                {
                    LeftDoor();
                }
                else if(buttonName == "LLightButton")
                {
                    LeftLight();
                }
                else if(buttonName == "RDoorButton")
                {
                    RightDoor();
                }
                else if(buttonName == "RLightButton")
                {
                    RightLight();
                }
                else
                {
                    print("nothing");
                }
                
            
                
            }
        }
        
    }


    void LeftDoor()
    {
        if(PowerScript.power > 0)
        {
            if(leftanim.GetBool("Closed") == false)
            {
                PowerScript.PowerCheck("on");
                leftanim.SetBool("Closed",true);
                Slam.Play();
                leftdoorbutton.GetComponent<MeshRenderer>().material = Green;
            }
            else
            {
                PowerScript.PowerCheck("off");
                leftanim.SetBool("Closed",false);
                leftdoorbutton.GetComponent<MeshRenderer>().material = Red;
            }
        }

    }

    void LeftLight()
    {
        if(PowerScript.power > 0)
        {
            if (LightState == ON)
            {
                LightState = OFF;
                leftlightbutton.GetComponent<MeshRenderer>().material = White;
                Buzz.Stop();
                PowerScript.PowerCheck("off");
                StopCoroutine(Lflickering());
                Leftlight.enabled = false;
            }
            else if (LightState == OFF)
            {
                LightState = ON;
                leftlightbutton.GetComponent<MeshRenderer>().material = Purple;
                Buzz.Play();
                PowerScript.PowerCheck("on");
                StartCoroutine(Lflickering());
            }
        }
        
    }

    void RightDoor()
    {
        if(PowerScript.power >0)
        {
            if(rightanim.GetBool("Closed") == false)
            {
                rightanim.SetBool("Closed",true);
                PowerScript.PowerCheck("on");
                rightdoorbutton.GetComponent<MeshRenderer>().material = Green;
                Slam.Play();
            }
            else
            {
                rightanim.SetBool("Closed",false);
                PowerScript.PowerCheck("off");
                rightdoorbutton.GetComponent<MeshRenderer>().material = Red;
            }
        }
       
    }

    void RightLight()
    {
        if(PowerScript.power > 0)
        {
            if (RLightState == ON)
            {
                RLightState = OFF;
                rightlightbutton.GetComponent<MeshRenderer>().material = White;
                Buzz.Stop();
                PowerScript.PowerCheck("off");
                StopCoroutine(Rflickering());
                Rightlight.enabled = false;
            }
            else if (RLightState == OFF)
            {
                RLightState = ON;
                rightlightbutton.GetComponent<MeshRenderer>().material = Purple;
                Buzz.Play();
                PowerScript.PowerCheck("on");
                StartCoroutine(Rflickering());
            }
        }
        

    }

    IEnumerator Lflickering()
    {
        while(LightState == ON)
        {
            yield return new WaitForSeconds(Random.Range(0.02f, 0.06f));
            Leftlight.enabled =true;
            yield return new WaitForSeconds(Random.Range(0.02f, 0.5f));
            Leftlight.enabled =false;
        }
    }

    IEnumerator Rflickering()
    {
        while(RLightState == ON)
        {
            yield return new WaitForSeconds(Random.Range(0.02f, 0.06f));
            Rightlight.enabled =true;
            yield return new WaitForSeconds(Random.Range(0.02f, 0.5f));
            Rightlight.enabled =false;
        }
    }

    void PowerOutage()
    {
        PowerScript.powerUsage = 0;
        LightState = OFF;
        leftlightbutton.GetComponent<MeshRenderer>().material = White;
        Buzz.Stop();
        StopCoroutine(Lflickering());
        Leftlight.enabled = false;

        leftanim.SetBool("Closed",false);
        leftdoorbutton.GetComponent<MeshRenderer>().material = Red;

        rightanim.SetBool("Closed",false);
        rightdoorbutton.GetComponent<MeshRenderer>().material = Red;

        RLightState = OFF;
        rightlightbutton.GetComponent<MeshRenderer>().material = White;
        Buzz.Stop();
        StopCoroutine(Rflickering());
        Rightlight.enabled = false;
    }


}
