using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{
    public GameObject PauseB;
    private void Start()
    {
        PauseB.SetActive(true);
    }
}
