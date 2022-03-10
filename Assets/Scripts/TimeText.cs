using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
   public GameObject enemy;
   public float startTime;
   public Text text_Watch;
   

   private void Update()
   {
      if (enemy.GetComponent<EnemyController>().cam)
      {
         Timer();
      }
   }

   void Timer()
   {
      startTime += Time.deltaTime;
      text_Watch.text = Mathf.Round(startTime).ToString();
   }
}
