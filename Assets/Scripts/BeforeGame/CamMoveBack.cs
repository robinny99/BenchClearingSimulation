using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveBack : MonoBehaviour
{
    public float waitForSeconds;
    public Transform _transform;
    private void Start()
    {
        StartCoroutine(MoveBack());
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime);
    }

    IEnumerator MoveBack()
    {
       
        yield return new WaitForSeconds(waitForSeconds);
        transform.position = _transform.position;
        yield break;
    }
}
