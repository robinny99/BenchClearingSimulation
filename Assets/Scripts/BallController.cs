using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
   public Animator playerAnimator;
   public Animator enemyAnimator;
   public GameObject ballTwoController;
   private bool isReadyToThrow = false;
   private bool isReady;
   public GameObject cameraController;
   private void Awake()
   { 
      playerAnimator.SetBool("startFlag", false);  //1
   }

   private void Start()
   {
      StartCoroutine(PitchingCo());
   }

   void Update()
   {
      if (isReady)
      {
         if (Input.GetMouseButtonDown(0))
         {
            playerAnimator.SetBool("startFlag", true); //플레이어 피칭 애니메이션온
            StartCoroutine(WaitForOne());
         }
      }

      if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pitching")) //Pitching 일때 조건문
      {
         enemyAnimator.SetBool("IsReady", true); //준비파라미터 ISREADY
         playerAnimator.SetBool("startFlag", false);
      } 
      
      if (isReadyToThrow)
      {
         StopCoroutine(WaitForOne());
         cameraController.GetComponent<CameraController>().SwitchCameraFirstCamToballCam();
         if (ballTwoController != null)
         {
            ballTwoController.GetComponent<BallTwoController>().BallTwo(); //balltwo 함수호출
         }
         
      }

   }
   
   
   IEnumerator WaitForOne()
   {
      yield return new WaitForSeconds(1.0f);
      isReadyToThrow = true;
   }
   
   IEnumerator PitchingCo()
   {
      yield return new WaitForSeconds(3);

      isReady = true;
      yield break;
   }
}

//문제: IEnumerator이 계속돌아간다. //해결