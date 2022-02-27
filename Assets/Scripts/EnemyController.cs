using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public GameObject redBox;
    private bool isHit = true;
    public Animator playerAnimator;
    public Animator enemyanimator;
    public GameObject cameraController;
    public bool isStay = false;
    private bool stopCo = false;
    public bool readyToRun = false;
    public bool cam = false;
    public GameObject ballTwoController;
    public GameObject player;


    public bool posuKnockback;
    //public Rigidbody enemyRb;
    //public float runSpeed = 10.0f;
    //public float walkSpeed = 1.0f;
    
    //public float speed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (isHit)
        {
            if (other.gameObject.tag == "Ball")
            {
                posuKnockback = true;
                enemyanimator.SetBool("IsReady", false);
                enemyanimator.SetBool("IsHitted", true);
                isStay = true;
                if (ballTwoController != null)
                {
                    ballTwoController.GetComponent<BallTwoController>().BallFalse();
                }
                isHit = false;
                StartCoroutine(Disappear());
            }
        }
    }
    private void FixedUpdate()
    {
        if (cam)
        {
            cameraController.GetComponent<CameraController>().SwitchCamLookDownCamToOverCam(); //on / off
            //Attack();
        }
        if (stopCo)
        {
            cam = true;
            StopCoroutine(Waitfortwo());
            readyToRun = true; 
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
        yield return new WaitForSeconds(1.0f);
        cameraController.GetComponent<CameraController>().SwitchCamLookDownCamToOverCam(); //on / off
        stopCo = true;
        isStay = false;
        
    }

    /*public void Attack()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance < 3.0f)    //코앞에서 공격
        {
            Vector3 moveVec;
            transform.LookAt(player.transform);
            enemyanimator.SetTrigger("IsBound");
            moveVec = new Vector3(0,0,0).normalized;
            transform.position += moveVec;
        }
        else if (distance <= 20.0f && distance >= 3.0f)
        { 
            if (enemyanimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
                enemyanimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f) //Attack 일때 조건문
            {
                transform.LookAt(player.transform);
                transform.Translate(Vector3.zero);
            }
            if (!enemyanimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                transform.Translate(Vector3.forward * speed);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * speed);
            transform.LookAt(player.transform);
        }
    }*/
    
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        
        yield break;
        
    }
}