using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePosuController : MonoBehaviour
{
    public GameObject targetEnemy;
    public GameObject EnemyBatterChildren;
    public Animator _animator;
    private bool isAttack;
    public GameObject AttackBall;

    public float speed;

    private void Awake()
    {
        AttackBall.SetActive(false);
    }

    private void Update()
    {
        if (EnemyBatterChildren.GetComponent<EnemyController>().posuKnockback)
        {
            Debug.Log("넉백 시작");
           _animator.SetTrigger("IsKnockback");

           if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") &&
               _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
           {
               isAttack = true;
           }
        }

        if (isAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        float distance = Vector3.Distance(transform.position, targetEnemy.transform.position);
        if (distance <= 10f)
        {
            _animator.SetTrigger("IsAttack");
            if (AttackBall != null)
            {
                AttackBall.SetActive(true);   
            }
            Debug.Log("공던짐");
        }
        else if(distance < 20f && distance >10f)
        {
            transform.Translate(Vector3.forward * speed);
        }
        else
        {
            transform.LookAt(targetEnemy.transform.position);
        }
    }
}
