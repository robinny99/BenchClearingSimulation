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
    private EnemyController enemyController;

    private bool isTouch = false;
    private bool a = true;
    
    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
    }

    //private void Update()
    //{
        /*if (playerAnimator.GetCurrentAnimatorStateInfo(1).IsName("Knockback") &&
            playerAnimator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0f)
        {
            Debug.Log("넉백애니메이션이 실행중 aa");
            CantMove();
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(1).IsName("Knockback") &&
            playerAnimator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.5f)
        {
            playerAnimator.SetBool("aaa", false);
            Debug.Log("피격상태가아님");
        }*/
    //}

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

        if (hAxis == 0 && vAxis == 0 || hAxis == null || vAxis == null)
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
        if (enemyController.GetComponent<EnemyController>().cam)
        {
            if (other.gameObject.tag != "Structure")
            {
                Debug.Log("플레이어에 닿은 오브젝트 이름 : " + other.gameObject.name);
                playerAnimator.SetTrigger("IsKnockBack");
                isTouch = true;
            }
        }

        /*
        if (other.gameObject.tag == "Blue")
        {
            playerAnimator.SetBool("aaa", true);
            moveVec = new Vector3(0, 0, 0).normalized;
            transform.position += moveVec;
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine("knockback", reactVec);
            a = false;
        }*/
    }

    /*
    IEnumerator knockback(Vector3 reactVec)
    {

        Debug.Log("넉백중 뒤로 물러남");
        reactVec = reactVec.normalized;
        reactVec = Vector3.up;
        playerRigidbody.AddForce(reactVec * backSpace, ForceMode.Impulse);
        //reactVec = Vector3.zero;
        yield return new WaitForSeconds(0.8f);
        a = true;
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        
    }*/
    
}
