using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToLineUpL : MonoBehaviour
{
    public float walkingTime;
    public Animator _animator;
    public Transform center;
 
    private void Start()
    {
        StartCoroutine(StartIdle());
    }
    
    IEnumerator StartIdle()
    {
        yield return new WaitForSeconds(24f);
        _animator.SetBool("IsLeft",true);
        yield return new WaitForSeconds(walkingTime);
        _animator.SetBool("IsIdle", true);
        transform.LookAt(center);
        yield break;
    }
}
