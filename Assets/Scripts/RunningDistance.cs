using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningDistance : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Text moveRecordText;
    
    float moveDistance;
    float distanceRecord;
    
    private void Update()
    {
        GameStart();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    void GameStart()
    {
        if (enemy.GetComponent<EnemyController>().cam)
        {
            MoveRecord();
            ShowMoveRecord();
        }
    }
    
    void MoveRecord()
    {
        moveDistance = 5 * player.GetComponent<PlayerMovement>().runningTime;
        distanceRecord = moveDistance;
    }
    
    //-----------------------------------------<UI>----------------------------------------------------------//
    
    public void ShowMoveRecord()
    {
        moveRecordText.text = distanceRecord.ToString("F1");
    }
}
