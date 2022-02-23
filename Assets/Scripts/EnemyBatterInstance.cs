using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatterInstance : MonoBehaviour
{
    public float speed;
    public Animator redBatter;
    public GameObject player;
    public bool check = true;
    public bool isDead;
    void Start()
    {
        redBatter.SetTrigger("IsNotHit");
    }

    private void Update()
    {
        if (check)
        {
            redBatter.SetTrigger("IsNotHit");
            Debug.Log("check이 활성화됨");
            check = false;
        }
        
    }
    void FixedUpdate()
    {
        if (isDead != true)
        {
            Attack();
        }
    }
    
    public void Attack()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 3.0f) //코앞에서 공격
        {
            redBatter.SetTrigger("IsBound");
            
            transform.LookAt(player.transform);
            
            Vector3 moveVec;
            moveVec = new Vector3(0, 0, 0).normalized;
            transform.position += moveVec;
            Debug.Log("사정거리 안");
        }
        else if (distance <= 30.0f && distance >= 3.0f)
        {
            if (redBatter.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
                redBatter.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                transform.LookAt(player.transform);
                transform.Translate(Vector3.zero);
            }

            if (!redBatter.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Blue")
        {
            redBatter.SetTrigger("IsDead");
            isDead = true;
        }

        if (other.gameObject.tag == "enemy")
        {
            redBatter.SetTrigger("IsKnockback"); //중간에 애니메이션 안끊기게
            transform.LookAt(other.transform.position - transform.position);
        }
    }
}
