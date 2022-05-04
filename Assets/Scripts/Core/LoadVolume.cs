using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadVolume : MonoBehaviour
{
    float volumeValue;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        volumeValue = PlayerPrefs.GetFloat("Volume");
        mixer.SetFloat("MasterVol", Mathf.Log10(volumeValue)*20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
