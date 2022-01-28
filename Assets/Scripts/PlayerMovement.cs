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

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {

        EnemyController enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
        if (enemyController.readyToRun == true)
        {
            Debug.Log("#10 본게임 시작");

            GetInput();
            Move();
            Turn();
            PlayerAnimation();
        }
    }
    void GetInput()
        {
            hAxis = Input.GetAxis("Horizontal");
            vAxis = Input.GetAxis("Vertical");
        }
        
        void Move()
        {
            moveVec = new Vector3(hAxis,0,vAxis).normalized;
            transform.position += moveVec * moveSpeed * Time.deltaTime;
           
            
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
                Debug.Log("멈춤");
            }
            else
            {
                playerAnimator.SetBool("IsRun", true);     
                Debug.Log("뛰는 중");
            }
            
                
           
            
        }
}