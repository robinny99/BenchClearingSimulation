using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target;

    private void Start()
    {
        StartCoroutine(aaa());
    }
    IEnumerator aaa()
    {
        yield return new WaitForSeconds(5.0f);
        if (enemy.GetComponent<EnemyController>().cam)
        {
            Debug.Log("인스턴스 4마리 소환");
            Instantiate(target, transform.position,transform.rotation);
        }
    }
}
