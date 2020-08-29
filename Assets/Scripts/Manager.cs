using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager instance = null;
    public bool teleportation = true;
    public bool music = true;
    public bool noise = false;
    public bool rain = false;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }
}
