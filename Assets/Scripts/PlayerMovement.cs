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
    private EnemyController enemyController;

    private bool isTouch = false;
    //private bool a = false;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if (enemyController.readyToRun)
        {
            if (isTouch)
            {
                CantMove();
            }
            else
            {
                Move();
                Turn();
                PlayerAnimation();
            }
        }
    }

    void CantMove()
    {
        moveVec = new Vector3(0, 0, 0).normalized;
        transform.position += moveVec;
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
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
        }
        else
        {
            playerAnimator.SetBool("IsRun", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Structure")
        {
            Debug.Log("플레이어에 닿은 오브젝트 이름 : " + other.gameObject.name);
            playerAnimator.SetTrigger("IsKnockBack");
            isTouch = true;
        }
    }
}
