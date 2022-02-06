using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private float hAxis;
    private float vAxis;
    
    private Vector3 moveVec;

    public float moveSpeed = 3.0f;
    public Animator playerAnimator;
    private Rigidbody playerRigidbody;

    private bool isTouch = false;
    private bool a = false;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        /*BatHide bat = GameObject.Find("EnemyBetterChildren").GetComponent<BatHide>();
        if (bat.isDied)
        {
            playerAnimator.SetTrigger("IsKnockBack");
            Debug.Log("빠따에 맞았따!");
        }*/

        EnemyController enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
        if (enemyController.readyToRun)
        {
            if (isTouch)
            {
                Debug.Log("움직임 불가능");
                CantMove();
            }
            else
            {
                Debug.Log("움직임 가능");
                Move();
                Turn();
                PlayerAnimation();
            }
            
        }
    }
    void CantMove()
        {
            moveVec = new Vector3(0,0,0).normalized;
            transform.position += moveVec;
        }
        
        void Move()
        {
            moveVec = new Vector3(hAxis,0,vAxis).normalized;
            transform.position += moveVec * moveSpeed * Time.deltaTime;
            hAxis = Input.GetAxis("Horizontal");
            vAxis = Input.GetAxis("Vertical");
            
        }

        void Turn()
        {
            transform.LookAt(transform.position + moveVec);
        }

        void PlayerAnimation()
        {

            if (hAxis == 0 && vAxis == 0)
            {
                playerAnimator.SetBool("IsRun", false);
                //Debug.Log("멈춤");
            }
            else
            {
                playerAnimator.SetBool("IsRun", true);     
                //Debug.Log("뛰는 중");
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Blue")
            {
                playerAnimator.SetTrigger("IsKnockBack");
                Debug.Log("플레이어 - 닿음");// 공맞으면 게임종료   
            }
            isTouch = true;
        }
}
