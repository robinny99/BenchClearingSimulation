using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private bool isHit = true;
    public Animator playerAnimator;
    public Animator enemyanimator;
    public GameObject cameraController;
    private bool isStay = false;
    private bool stopCo = false;
    public bool readyToRun = false;
    public bool cam = false;
    public GameObject ballTwoController;
    public GameObject player;
    //public Rigidbody enemyRb;
    public float runSpeed = 10.0f;
    public float walkSpeed = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (isHit)
        {
            if (other.gameObject.tag == "Ball")
            {
                enemyanimator.SetBool("IsReady", false);
                enemyanimator.SetBool("IsHitted", true);
                Debug.Log("#5 물체와 충돌");
                isStay = true;
                if (ballTwoController != null)
                {
                    ballTwoController.GetComponent<BallTwoController>().BallFalse();
                }
                isHit = false;
            }
        }
    }

    private void Start()
    {
        //enemyRb.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (cam)
        {
            cameraController.GetComponent<CameraController>().SwitchCamLookDownCamToOverCam(); //on / off
            Attack();
        }
        if (stopCo)
        {
            cam = true;
            StopCoroutine(Waitfortwo());
            readyToRun = true;  //다른스크립트로 이동
            playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("Base Layer"), 0);
            playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("PlayerMovement"), 1);
        }
        if (isStay)
        {
            cameraController.GetComponent<CameraController>().SwitchBallCamToLookDownCam(); //공이 맞은직 후 
            StartCoroutine(Waitfortwo());
        }
    }
    IEnumerator Waitfortwo()
    {
        //Debug.Log("#7 1초 대기 후 내려다 보는 캠To 플레이어캠");
        yield return new WaitForSeconds(1.0f);
        cameraController.GetComponent<CameraController>().SwitchCamLookDownCamToOverCam(); //on / off
        stopCo = true;
        isStay = false;
    }

    public void Attack()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance < 4.0f)
        {
            Debug.Log("공격");
            Vector3 moveVec;
            transform.LookAt(player.transform);
            enemyanimator.SetTrigger("IsBound");
            moveVec = new Vector3(0,0,0).normalized;
            transform.position += moveVec;
        }
        else if (distance <= 15.0f && distance >= 4.0f)
        { 
            if (enemyanimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && enemyanimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f) //Pitching 일때 조건문
            {
                transform.LookAt(player.transform);
                transform.Translate(Vector3.zero);
                Debug.Log("공격중");
            }
            if (!enemyanimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                Debug.Log("20미만");
                transform.Translate(Vector3.forward * 0.15f);
                Debug.Log("공격끝");
            }
        }
        else
        {
            Debug.Log("30이상");
            transform.Translate(Vector3.forward * 0.15f);
            transform.LookAt(player.transform);
        }
    }
}