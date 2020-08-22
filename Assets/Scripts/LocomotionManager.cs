using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocomotionManager : MonoBehaviour
{
    [SerializeField] GameObject locomotionController;
    [SerializeField] Toggle teleportToggle;

    private void Start()
    {
        ConfigTeleport(false);
    }

    public void ToggleTeleport()
    {
        Manager.instance.teleportation = !Manager.instance.teleportation;
        locomotionController.SetActive(Manager.instance.teleportation);
    }

    public void ConfigTeleport(bool notify)
    {
        locomotionController.SetActive(Manager.instance.teleportation);
        if (notify) teleportToggle.isOn = Manager.instance.teleportation;
        else teleportToggle.SetIsOnWithoutNotify(Manager.instance.teleportation);
    }
}
