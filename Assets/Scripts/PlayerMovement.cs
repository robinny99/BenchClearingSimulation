using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float hAxis;
    private float vAxis;

    private Vector3 moveVec;

    public float moveSpeed = 1.0f;
    public Animator playerAnimator;
    public GameObject whiteBat;
    private EnemyController enemyController;

    private bool isTouch = false;
    private bool a = true;
    private bool isDead;

    private void Start()
    {
        whiteBat.SetActive(false);
        playerAnimator = GetComponentInChildren<Animator>();
        enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(2).IsName("BatAttack") &&
            playerAnimator.GetCurrentAnimatorStateInfo(2).normalizedTime >= 0f)
        {
            CantMove();
        }
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
                if (Input.GetKey(KeyCode.Space) && whiteBat.activeSelf)
                {
                    playerAnimator.SetTrigger("IsAttack");
                    playerAnimator.SetLayerWeight(2, 1);
                }
                else
                {
                    playerAnimator.SetLayerWeight(2, 0);
                }
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

        if (hAxis == 0 && vAxis == 0 || hAxis == null || vAxis == null || ( hAxis == null && vAxis == null))
        {
            playerAnimator.SetBool("IsRun", false);

            if (isDead)
            {
                
            }
        }
        else
        {
            playerAnimator.SetBool("IsRun", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyController.GetComponent<EnemyController>().cam)
        {
            if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Judge")
            {
                Debug.Log("플레이어에 닿은 오브젝트 이름 : " + other.gameObject.name);
                playerAnimator.SetTrigger("IsKnockBack");
                isTouch = true;
            }
        }
    }
}
