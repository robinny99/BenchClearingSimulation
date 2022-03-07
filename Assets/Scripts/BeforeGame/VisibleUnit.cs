using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleUnit : MonoBehaviour
{
   

   public float lateSeconds;
   public GameObject[] blueUnits;
   public GameObject[] redUnits;

   private void Awake()
   {
      for (int i = 0; i < 10; i++)
      {
         blueUnits[i].SetActive(false);
         redUnits[i].SetActive(false);
      }
   }

   private void Start()
   {
      StartCoroutine(BlueVisible());
      StartCoroutine(RedVisible());
   }
   IEnumerator BlueVisible()
   {
      for (int i = 0; i < 10; i++)
      {
         yield return new WaitForSeconds(lateSeconds);
         blueUnits[i].SetActive(true);
      }
   }

   IEnumerator RedVisible()
   {
      for (int i = 0; i < 10; i++)
      {
         yield return new WaitForSeconds(lateSeconds);
         redUnits[i].SetActive(true);
      }
   }
}
