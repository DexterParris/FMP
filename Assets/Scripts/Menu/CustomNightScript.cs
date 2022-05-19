using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomNightScript : MonoBehaviour
{

    public Slider frankslider;
    public Slider bernardslider;
    public Slider helenslider;
    public Slider orvilleslider;
    public TextMeshProUGUI slidertext;

    // Start is called before the first frame update
    void Start()
    {
        frankslider.maxValue = 20;
        bernardslider.maxValue = 20;
        helenslider.maxValue = 20;
        orvilleslider.maxValue = 20;

        frankslider.value = PlayerPrefs.GetInt("frankActivity");
        bernardslider.value = PlayerPrefs.GetInt("bernardActivity");
        helenslider.value = PlayerPrefs.GetInt("helenActivity");
        orvilleslider.value = PlayerPrefs.GetInt("orvilleActivity");

    }

    public void Frankslider()
    {
        PlayerPrefs.SetInt("frankActivity",(int)frankslider.value);
    }

    public void Bernardslider() 
    {
        PlayerPrefs.SetInt("bernardActivity", (int)bernardslider.value);
    }
    public void Helenslider()
    {
        PlayerPrefs.SetInt("helenActivity", (int)helenslider.value);
    }
    public void Orvilleslider()
    {
        PlayerPrefs.SetInt("orvilleActivity", (int)orvilleslider.value);
    }

    private void Update()
    {
        slidertext.text = (PlayerPrefs.GetInt("frankActivity").ToString("00") +" "+ PlayerPrefs.GetInt("bernardActivity").ToString("00") + " " + PlayerPrefs.GetInt("helenActivity").ToString("00") + " " + PlayerPrefs.GetInt("orvilleActivity").ToString("00"));
        slidertext.wordSpacing = 385.04f;
    }
}
