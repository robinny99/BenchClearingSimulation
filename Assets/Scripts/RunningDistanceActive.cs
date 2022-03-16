using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDistanceActive : MonoBehaviour
{
    public GameObject runningRecordText;
    public GameObject Meter;

    private void Start()
    {
        runningRecordText.SetActive(true);
        Meter.SetActive(true);
    }
}
