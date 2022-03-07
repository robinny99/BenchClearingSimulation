using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToLineUpR : MonoBehaviour
{
    public float walkingTime;
    public Animator _animator;
    public Transform center;
 
    private void Start()
    {
        StartCoroutine(StartIdle());
        StartCoroutine(SecondIdle());
    }
    
    IEnumerator StartIdle()
    {
        yield return new WaitForSeconds(22f);
        _animator.SetBool("IsRight",true);
       
    }

    IEnumerator SecondIdle()
    {
        yield return new WaitForSeconds(walkingTime);
        _animator.SetBool("IsIdle", true);
        transform.LookAt(center);
        yield break;
    }
}
