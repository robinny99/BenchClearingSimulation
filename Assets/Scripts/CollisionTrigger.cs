using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject armedWhiteBat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            armedWhiteBat.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("방망이 닿았다 획득!");
        }
        Debug.Log("방망이 닿았다 획득!");
    }
}
