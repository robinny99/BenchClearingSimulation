using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBatterController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Animator redBatter;
    private bool trig;

    public float speed;
    
    private Vector3 moveVec;

    private bool isAttack = true;
    
    //public Transform spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "whiteBat")
        {
            redBatter.SetTrigger("IsDead");
            transform.Translate(Vector3.zero);
            trig = false;
        }
    }

    private void Update()
    {
        if (enemy.GetComponent<EnemyController>().cam)
        {
            trig = true;
            redBatter.SetTrigger("IsNotHit");
            
            if (redBatter.GetCurrentAnimatorStateInfo(0).IsName("Run") &&
                redBatter.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                isAttack = true;
            }
            if (redBatter.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
                redBatter.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                isAttack = false;
            }
            if (redBatter.GetCurrentAnimatorStateInfo(0).IsName("Die") &&
                redBatter.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
            {
                isAttack = false;
                transform.LookAt(Vector3.forward);
                StartCoroutine(DisAppear());
            }
        }
    }

    void FixedUpdate()
    {
        if (trig)
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

    IEnumerator DisAppear()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        yield break;
    }
}
