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
    private Vector3 moveVec;

    private void Update()
    {
        if (EnemyBatterChildren.GetComponent<EnemyController>().posuKnockback)
        {
            _animator.SetBool("IsStart", true);

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && //뛰는 애니메이션이 실행되고 있을 때
                _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                isAttack = true;
            }
        }

        if (isAttack)
        {
            Attack();
        }

        if (isAttack != true) //죽었을 떄
        {
            moveVec = new Vector3(0, 0, 0).normalized; //움직임 고정
            transform.position += moveVec;
            transform.LookAt(Vector3.forward);
        }
    }

    void Attack()
    {
        float distance = Vector3.Distance(transform.position, targetEnemy.transform.position);
        if (distance <= 3f)
        {
            transform.LookAt(targetEnemy.transform.position);
        }
        else if (distance > 3f)
        {
            /*transform.Translate(Vector3.forward * speed);*/
            transform.LookAt(targetEnemy.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WhiteBat") //지형, 파란색유닛 제외
        {
            _animator.SetTrigger("IsDead");
            isAttack = false;
            transform.LookAt(Vector3.forward);
        }
    }
}
