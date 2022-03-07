using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecam : MonoBehaviour
{
   public float timeToSwitch;
   public GameObject[] cam;
   private void Awake()
   {
      for (int i = 1; i < 4; i++)
      {
         cam[i].SetActive(false);
      }
   }
   private void Start()
   {
      StartCoroutine(SwitchCam());
   }
   IEnumerator SwitchCam()
   {
      while (true)
      {
         yield return new WaitForSeconds(timeToSwitch);
               cam[0].SetActive(true);
               cam[1].SetActive(false);
               cam[2].SetActive(false);
               cam[3].SetActive(false);
               yield return new WaitForSeconds(timeToSwitch);
               cam[0].SetActive(false);
               cam[1].SetActive(true);
               cam[2].SetActive(false);
               cam[3].SetActive(false);
               yield return new WaitForSeconds(timeToSwitch);
               cam[0].SetActive(false);
               cam[1].SetActive(false);
               cam[2].SetActive(true);
               cam[3].SetActive(false);
               yield return new WaitForSeconds(timeToSwitch);
               cam[0].SetActive(false);
               cam[1].SetActive(false);
               cam[2].SetActive(false);
               cam[3].SetActive(true);
      }
      
   }
}
