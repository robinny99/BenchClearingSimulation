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
    public bool isDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Blue")
        {
            _animator.SetTrigger("IsDead");
            isDead = true;
        }

        if (other.gameObject.tag == "enemy")
        {
            _animator.SetTrigger("IsKnockback");
            transform.LookAt(other.transform.position - transform.position);
        }
    }

    private void Update()
    {
        if (enemy.GetComponent<EnemyController>().cam)
        {
            _animator.SetTrigger("IsStart");
            trigger = true;

            if (isDead)
            {
                transform.Translate(Vector3.zero);
                Debug.Log("멈춤");
            }
        }
    }

    private void FixedUpdate()
    {
        if (trigger)
        {
            if (isDead != true)
            {
                Attack();
            }

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
                _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                transform.LookAt(player.transform);
                transform.Translate(Vector3.zero);
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
                    transform.LookAt(player.transform);
                }
            }
            else
            {
                transform.Translate(Vector3.forward * speed);
                transform.LookAt(player.transform);
            }
        }
    }
}
