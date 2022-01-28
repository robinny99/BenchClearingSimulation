using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Camera firstStepCamera;
   public Camera ballCamera;
   public Camera lookDownCam;
   public Camera overViewCamera;

   private void Awake()
   {
      firstStepCamera.enabled = true;
      ballCamera.enabled = false;
      overViewCamera.enabled = false;
      lookDownCam.enabled = false;
   }

   public void SwitchCameraFirstCamToballCam() //공이손을 떠난 순간
   {
      firstStepCamera.enabled = false;
      ballCamera.enabled = true;
   }

   public void SwitchBallCamToLookDownCam()
   {
      ballCamera.enabled = false;
      lookDownCam.enabled = true;
   }
   public void SwitchCamLookDownCamToOverCam()
   {
       firstStepCamera.enabled = false;
      ballCamera.enabled = false;
      lookDownCam.enabled = false;
      overViewCamera.enabled = true; //카메라전환

   }
}
