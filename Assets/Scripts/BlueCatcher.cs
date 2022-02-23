using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCatcher : MonoBehaviour
{
    public Animator blueCatherAnimator;
    public GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        blueCatherAnimator.SetBool("IsDead" , true);
        
        /*if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "Ball" || other.gameObject.tag == "Bat")
        {
            
        }*/
    }

    private void Update()
    {
        EnemyController enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
        if (enemyController.readyToRun)
        {
            blueCatherAnimator.SetBool("IsStart" , true);
            transform.Translate(Vector3.forward * 0.1f);
            transform.LookAt(enemy.transform.position);
        }
       
    }
}
