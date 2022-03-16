using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class TimeText : MonoBehaviour
{
   public GameObject player;
   public GameObject enemy;
   public float startTime;
   public Text text_Watch;
   public Text result;
   public GameObject alpha;

   string time;

   private void Start()
   {
      SettingResult();
   }

   private void Update()
   {
      if (enemy.GetComponent<EnemyController>().cam)
      {
         if (player.GetComponent<PlayerMovement>().isDead != true)
         {
            Result();
         }
         else
         { 
            SwitchResult();
         }
      }
   }


   void SettingResult()
   {
      text_Watch.enabled = true;
      result.enabled = false;
      alpha.SetActive(false);
   }
   
   void SwitchResult()
   {
      text_Watch.enabled = false;
      StartCoroutine(ResultCo());
   }

   void Result()
   {
      TimeGoesOn();
      text_Watch.text = time;
      result.text = time;
   }

   void TimeGoesOn()
   {
      startTime += Time.deltaTime;
      time = Mathf.Round(startTime).ToString();
   }

   IEnumerator ResultCo()
   {
      yield return new WaitForSeconds(3f);
      alpha.SetActive(true);
      result.enabled = true;
      
      yield break;
   }
}
