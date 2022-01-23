using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BallTwoController : MonoBehaviour
{
    public Camera ballCamera;
    public float ballVelocity = 0.9f;
    public GameObject targetPosition;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void BallTwo()
    {
        gameObject.SetActive(true);
        transform.Rotate(new Vector3(60,60,60));
        transform.position = 
            Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, ballVelocity);
        ballCamera.transform.position = transform.position + Vector3.back;
    }
}

//2번 공활성화, 2번공 이동