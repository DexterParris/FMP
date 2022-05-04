using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{

    //audio stuff
    float volumeValue;
    public AudioMixer mixer;
    public TextMeshProUGUI volumeText;
    public Slider vSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeValue = PlayerPrefs.GetFloat("Volume");
        vSlider.value = volumeValue;

    }

    public void ChangeMasterVolume()
    {
        volumeValue = vSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        volumeText.text = (volumeValue*100).ToString("F0")+"%";
        if(volumeValue == 0f)
        {
            mixer.SetFloat("MasterVol", -80f);
        }
        else
        {
            mixer.SetFloat("MasterVol", Mathf.Log10(volumeValue)*20);
        }
    }

    
}
