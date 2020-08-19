using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject locomotionController;
    [SerializeField] Transform pausePosition;
    [SerializeField] Transform tempPlayerPosition;
    protected bool paused = false;

    public List<GameObject> pauseItems;
    public List<GameObject> gameItems;

    private void Update() 
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        if (paused)
        {
            SavePlayerPosition();
        }
        ToggleLocomotionController();
        TogglePauseGameItems();
        Teleport();
    }

    private void TogglePauseGameItems()
    {
        foreach (GameObject item in pauseItems) {
            item.SetActive(paused);
        }

        foreach (GameObject item in gameItems) {
            item.SetActive(!paused);
        }
    }

    private void Teleport()
    {
        if (paused)
        {
            player.transform.position = pausePosition.position;
            player.transform.rotation = pausePosition.rotation;
        }
        else
        {
            player.transform.position = tempPlayerPosition.position;
            player.transform.rotation = tempPlayerPosition.rotation;
        }
    }

    private void SavePlayerPosition()
    {
        tempPlayerPosition.position = player.transform.position;
        tempPlayerPosition.rotation = player.transform.rotation;
    }

    private void ToggleLocomotionController()
    {
        locomotionController.SetActive(!paused);
    }
}