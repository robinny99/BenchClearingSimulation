using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool isHit = false;
    public Animator playerAnimator;
    public Animator enemyanimator;
    public GameObject cameraController;
    //public GameObject ballTwoController;
    //public GameObject playerMovement;
    private bool isStay = false;
    private bool stopCo = false;
    public bool readyToRun = false;
    public bool cam = false;
    public GameObject ballTwoController;
    private CapsuleCollider _capsuleCollider;
    private void OnTriggerEnter(Collider other)
    {
        isHit = true;
        if (isHit)
        {   
            enemyanimator.SetBool("IsReady", false);
            enemyanimator.SetBool("IsHitted", true);
            Debug.Log("#5 물체와 충돌");
            isStay = true;
            if (ballTwoController != null)
            {
                ballTwoController.GetComponent<BallTwoController>().BallFalse();
            }
            
        }
    }
    private void Update()
    {
        if (cam)
        {
            Debug.Log("#9 플레이어 카메라 온");
            cameraController.GetComponent<CameraController>().SwitchCamLookDownCamToOverCam(); //on / off
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _capsuleCollider.isTrigger = false;
        }
        if (stopCo)
        {
            Debug.Log("#8 플레이어 애니메이터 레이어1 온");
            cam = true;
            StopCoroutine(Waitfortwo());
            readyToRun = true;  //다른스크립트로 이동
            playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("Base Layer"), 0);
            playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("PlayerMovement"), 1);
        }
        if (isStay)
        {
            Debug.Log("#6 코루틴 시작, 볼캠To맞은애캠");
            cameraController.GetComponent<CameraController>().SwitchBallCamToLookDownCam(); //공이 맞은직 후 
            StartCoroutine(Waitfortwo());
        }
    }
    IEnumerator Waitfortwo()
    {
        Debug.Log("#7 1초 대기 후 내려다 보는 캠To 플레이어캠");
        yield return new WaitForSeconds(1.0f);
        cameraController.GetComponent<CameraController>().SwitchCamLookDownCamToOverCam(); //on / off
        stopCo = true;
        isStay = false;
    }
    
    
}  