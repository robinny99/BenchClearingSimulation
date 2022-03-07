using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoBatter : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Animator _animator;
    public bool trigger;
    public float speed;
    private bool isAttack = true;
    
    private Vector3 moveVec;

    public Transform spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WhiteBat")
        {
            _animator.SetTrigger("IsDead");
            transform.Translate(Vector3.zero);
            isAttack = false;
        }
    }

    private void Update()
    {
        if (enemy.GetComponent<EnemyController>().cam)
        {
            _animator.SetTrigger("IsStart");
            trigger = true;
        }
    }

    private void FixedUpdate()
    {
        if (trigger)
        {
            if (isAttack)
            {
                Attack();
            }
            else
            {
                moveVec = new Vector3(0, 0, 0).normalized;
                transform.position += moveVec;
            }

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
                _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                transform.LookAt(player.transform);
                transform.Translate(Vector3.zero);
            }
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Die") &&
                _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                isAttack = false;
                transform.LookAt(Vector3.forward);
                DisAppear();
            }
        }

        void Attack()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < 3.0f)
            {
                _animator.SetTrigger("Attack");
                transform.LookAt(player.transform);

                Vector3 moveVec;
                moveVec = new Vector3(0, 0, 0).normalized;
                transform.position += moveVec;
            }
            else if (distance <= 20.0f && distance >= 3.0f)
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
                    _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f) //Attack 일때 조건문
                {
                    transform.LookAt(player.transform);
                    transform.Translate(Vector3.zero);
                }

                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    transform.Translate(Vector3.forward * speed);
                }
            }
            else
            {
                transform.Translate(Vector3.forward * speed);
                transform.LookAt(player.transform);
            }
        }
    }
    IEnumerator DisAppear()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        yield break;
    }
}
