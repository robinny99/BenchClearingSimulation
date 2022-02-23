using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class AttackBallMovement : MonoBehaviour
{
  public GameObject target;
  public GameObject posu;
  public Animator posuAnimator;
  public float power;

  private void Awake()
  {
    if (gameObject != null)
    {
      gameObject.SetActive(false);
    }
  }

  private void Update()
  {
    if (posuAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
        posuAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.1f)
    {
      if (gameObject != null)
      {
        gameObject.SetActive(true);
        transform.position = 
          Vector3.MoveTowards(transform.position, target.transform.position, power);
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (posuAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
        posuAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.1f)
    {
      transform.position = posu.transform.position + Vector3.forward;
    }
  }
}

