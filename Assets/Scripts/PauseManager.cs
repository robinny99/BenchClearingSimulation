using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] Text startPauseText;
    private bool pauseActive = false;

    public void pauseBtn()
    {
        if (pauseActive)
        {
            Time.timeScale = 1;
            pauseActive = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseActive = true;
        }

        startPauseText.text = pauseActive ? "R" : "P";
    }
}
