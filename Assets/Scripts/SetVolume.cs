using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {

    public AudioMixer mixer;

    private void Start() 
    {
        SetLevel(0);    
    }

    public void SetLevel (float sliderValue)
    {
        Debug.Log("Value changed.");
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}