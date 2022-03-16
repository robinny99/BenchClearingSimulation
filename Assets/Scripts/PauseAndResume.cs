using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 1;
    }
    
    public void Resume()
    {
        Time.timeScale = 0;
    }
}
