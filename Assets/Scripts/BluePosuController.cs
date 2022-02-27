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
    public float speed;

    public Transform spawner;
    
    private Vector3 moveVec;

    private void Update()
    {
               
    
        if (EnemyBatterChildren.GetComponent<EnemyController>().posuKnockback)
        {
            Debug.Log("넉백 시작");
           _animator.SetTrigger("IsStart");

           if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") &&
               _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
           {
               isAttack = true;
           }
           
           if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Die") &&
               _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
           {
               isAttack = false;
               transform.LookAt(Vector3.forward);
           }
        }

        if (isAttack)
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                Attack();   
            }
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Die") &&
                _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                isAttack = false;
                transform.LookAt(Vector3.forward);
            }
        }
        if (isAttack != true)
        {
            moveVec = new Vector3(0, 0, 0).normalized;
            transform.position += moveVec;
        }
    }

    void Attack()
    {
        float distance = Vector3.Distance(transform.position, targetEnemy.transform.position);
        if (distance <= 3f)
        {
            _animator.SetTrigger("IsAttack");
            transform.LookAt(targetEnemy.transform.position);
        }
        else if(distance >3f)
        {
            /*transform.Translate(Vector3.forward * speed);*/
            transform.LookAt(targetEnemy.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag != "Structure" || other.gameObject.tag != "Blue")
        {
            isAttack = false;
            _animator.SetTrigger("IsDead");
            transform.LookAt(Vector3.forward); //보는것 반대로 넘어져 죽음
            _animator.SetBool("IsRevive", false);
            StartCoroutine(Revive());
        }

        
    }
    
    IEnumerator Revive()
    {
        yield return new WaitForSeconds(2.5f);
        _animator.SetBool("IsRevive", true);
        transform.position = spawner.position;
        yield break;
    }
}
