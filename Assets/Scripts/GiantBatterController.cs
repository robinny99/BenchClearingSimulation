using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantBatterController : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    public GameObject player;
    public Animator giantAnimator;
    public Renderer[] rend = new Renderer[4];
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            rend[i].enabled = false;
        }

        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    public void Update()
    {
        if(enemy.GetComponent<EnemyController>().cam)
        {
            Debug.Log("볼 던짐");
            Invoke("Attack", 10f);
        }
    }

    public void Attack()
    {
        for (int i = 0; i < 3; i++)
        {
            rend[i].enabled = true;
        }
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        
        Debug.Log("자이언트 움직임");
        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance <= 15.0f)
        {
            giantAnimator.SetTrigger("IsRun");
            transform.Translate(Vector3.forward * speed);
        }
        else
        {
            transform.LookAt(player.transform);
        }
    }
}
