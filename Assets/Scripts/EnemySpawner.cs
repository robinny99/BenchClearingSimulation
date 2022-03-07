using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject target;

    private void Awake()
    {
        gameObject.GetComponent<EnemySpawner>().enabled = false;
    }

    private void Start()
    {
        StartCoroutine(aaa());
    }
    IEnumerator aaa()
    {
        while (true) {
            Instantiate (target, transform.position, transform.rotation);
            yield return new WaitForSeconds (10.0f);
        }
    }
}
