using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour
{
    [SerializeField] Canvas menu;
    [SerializeField] Transform player;
    [SerializeField] AudioSource audio;
    [SerializeField] Slider slider;
    [SerializeField] float menuHeight = 0.8f;
    protected bool paused = false;

    private void Start() 
    {
        // ToggleMenu();
    }

    private void Update() 
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            ToggleMenu();
        }
        if (paused)
        {
            audio.GetComponent<AudioSource>().volume = slider.value;
        }
    }

    public void ToggleMenu()
    {
        paused = !paused;
        menu.gameObject.SetActive(paused);
        if (paused)
        {
            PositionMenu();
        }
    }

    private void PositionMenu()
    {
        GameObject tempPlayer = new GameObject();
        tempPlayer.transform.position = player.transform.position;
        Quaternion tempRotation = player.transform.rotation;
        tempRotation.x = 0;
        tempRotation.z = 0;
        tempPlayer.transform.rotation = tempRotation;
        Destroy(tempPlayer);
        Vector3 spawnPos = tempPlayer.transform.forward * 1.5f + Vector3.up * menuHeight;
        menu.transform.position = spawnPos;
        menu.transform.eulerAngles = player.transform.eulerAngles;
    }
}

// GameObject tempPlayer = new GameObject();
//         tempPlayer.transform.position = player.transform.position;
//         Quaternion tempRotation = player.transform.rotation;
//         tempRotation.x = 0;
//         tempRotation.z = 0;
//         tempPlayer.transform.rotation = tempRotation;
//         Destroy(tempPlayer);
//         Vector3 spawnPos = player.transform.position + (tempPlayer.transform.forward * 1.5f) + Vector3.up * menuHeight;
//         menu.transform.position = spawnPos;
//         menu.transform.eulerAngles = player.transform.eulerAngles;