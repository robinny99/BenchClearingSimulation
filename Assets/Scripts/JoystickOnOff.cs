using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickOnOff : MonoBehaviour
{
    public GameObject Joystick;

    private void Start()
    {
        Joystick.SetActive(false);
    }

    public void JoystickOn()
    {
        Joystick.SetActive(true);
    }
    
    public void JoystickOff()
    {
        Joystick.SetActive(false);
    }
}
