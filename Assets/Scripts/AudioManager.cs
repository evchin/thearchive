using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource noise;
    [SerializeField] AudioSource rain;
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle noiseToggle;
    [SerializeField] Toggle rainToggle;

    private void Start()
    {
        ConfigAudio(false);
    }

    public void ToggleMusic()
    {
        Manager.instance.music = !Manager.instance.music;
        if (Manager.instance.music) music.Play();
        else music.Pause();
    }

    public void ToggleNoise()
    {
        Manager.instance.noise = !Manager.instance.noise;
        if (Manager.instance.noise) noise.Play();
        else noise.Pause();
    }

    public void ToggleRain()
    {
        Manager.instance.rain = !Manager.instance.rain;
        if (Manager.instance.rain) rain.Play();
        else rain.Pause();
    }

    public void ConfigAudio(bool notify)
    {
        if (Manager.instance.music) music.Play();
        if (Manager.instance.noise) noise.Play(); 
        if (Manager.instance.rain) rain.Play(); 
        
        if (notify) 
        {
            musicToggle.isOn = Manager.instance.music;
            noiseToggle.isOn = Manager.instance.noise;
            rainToggle.isOn = Manager.instance.rain;
        }
        else 
        {
            musicToggle.SetIsOnWithoutNotify(Manager.instance.music);
            noiseToggle.SetIsOnWithoutNotify(Manager.instance.noise);
            rainToggle.SetIsOnWithoutNotify(Manager.instance.rain);
        }
    }
}
