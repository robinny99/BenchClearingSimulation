using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeverRange : MonoBehaviour
{
   private RectTransform lever;
   private RectTransform rectTransform;

   [SerializeField]
   private float leverRange;

   private void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
   }

   
}