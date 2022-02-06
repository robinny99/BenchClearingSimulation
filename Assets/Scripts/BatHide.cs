using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHide : MonoBehaviour
{
    public bool isDied = false;
    public Animator playerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerAnimator.SetTrigger("IsKnockBack");
            Debug.Log("빠따에 맞았따!");
            isDied = true;
        }

        
    }
}
