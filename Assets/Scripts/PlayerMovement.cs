using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runningTime;
    
    private float hAxis;
    private float vAxis;

    private Vector3 moveVec;

    public float moveSpeed = 1.0f;
    public Animator playerAnimator;
    private EnemyController enemyController;

    public bool isTouch = false;
    public bool isDead;

    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
    }
    private void FixedUpdate()
    {
        if (enemyController.readyToRun)
        {
            if (isTouch)
            {
                playerAnimator.SetTrigger("IsKnockBack");
                CantMove();
            }
            else
            {
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

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void PlayerAnimation()
    {

        if (hAxis == 0 && vAxis == 0 || hAxis == null || vAxis == null || (hAxis == null && vAxis == null))
        {
            playerAnimator.SetBool("IsRun", false);
        }
        else
        {
            runningTime += Time.deltaTime;
            playerAnimator.SetBool("IsRun", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyController.cam)
        {
            if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Judge" || other.gameObject.tag == "blue")
            {
                playerAnimator.SetTrigger("IsKnockBack");
                isTouch = true;
                isDead = true;
            }
        }
    }
}
