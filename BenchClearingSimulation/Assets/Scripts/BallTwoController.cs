using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallTwoController : MonoBehaviour
{
    public Camera ballCamera;
    public float ballVelocity = 0.9f;
    public GameObject targetPosition;
    private void Awake()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
        
    }
    public void BallTwo()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
            transform.Rotate(new Vector3(60,60,60));
            transform.position = 
                Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, ballVelocity);
            ballCamera.transform.position = transform.position + Vector3.back;
        }
        
    }

    public void BallFalse()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
        
        
    }
}

//2번 공활성화, 2번공 이동