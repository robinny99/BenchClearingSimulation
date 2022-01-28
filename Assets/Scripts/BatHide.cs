using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHide : MonoBehaviour
{
    public GameObject enemy;
    private void Update()
    {
        if (enemy.GetComponent<EnemyController>().cam)
        {
            gameObject.SetActive(false);
        }
    }
}
