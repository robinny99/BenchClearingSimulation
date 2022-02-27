using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeController : MonoBehaviour
{
    public Animator _animator;
    public Transform playerPosition;
    public bool IsStartAttack;

    private void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (IsStartAttack)
        {
            transform.LookAt(playerPosition);  
            _animator.SetTrigger("IsRun");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsStartAttack = true;
        }
    }
}
