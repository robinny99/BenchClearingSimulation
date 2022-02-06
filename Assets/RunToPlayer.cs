using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.PackageManager;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;



public class RunToPlayer : MonoBehaviour
{
    public GameObject player;
    public Animator red;
    public GameObject enemy;

    public float runSpeed;


    private void FixedUpdate()
    {
        /*if (enemy.GetComponent<EnemyController>().cam)
        {
            Debug.Log("게임시작!!!!!!");
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < 17.0f)
            {
                red.SetTrigger("Run");
                Debug.Log("반경내로 들어왔다!!!!!!");
                transform.Translate(Vector3.forward * runSpeed);
                //transform.position = Vector3.Lerp(transform.position, Vector3.forward * 10f, 0.1f);
            }
            else
            {
                red.SetTrigger("Walk");
                transform.LookAt(player.transform);
                Debug.Log("반경 밖이다!!!!!");
            }
        }*/
    }
}
