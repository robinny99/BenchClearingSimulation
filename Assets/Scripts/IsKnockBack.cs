using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKnockBack : MonoBehaviour
{
    public Animator playerAnimator;
    private void OnTriggerEnter(Collider other)
    {
        playerAnimator.SetTrigger("IsKnockBack");
    }
}
