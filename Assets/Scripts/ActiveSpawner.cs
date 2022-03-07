using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject timer;
    void Start()
    {
        spawner.GetComponent<EnemySpawner>().enabled = false;
    }
    private void Update()
    {
        if (timer.GetComponent<TimeText>().startTime > 0f)
        {
            spawner.GetComponent<EnemySpawner>().enabled = true;
        }
    }
}
