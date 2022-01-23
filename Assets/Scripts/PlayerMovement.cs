using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {
 
    public Animator playerAnimator;
    public float playerSpeed = 3.0f;
    public Rigidbody rigidbody;
    private Vector3 movement = new Vector3();
    private void Update()
    {
        
        EnemyController enemyController = GameObject.Find("EnemyBetterChildren").GetComponent<EnemyController>();
        if (enemyController.readyToRun == true)
        {
            Debug.Log("#10 본게임 시작");
        }
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rigidbody.velocity = movement * playerSpeed;
        playerAnimator.SetFloat("Forward",movement.y);
    }
}