using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBat : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(30 * Time.deltaTime,30 * Time.deltaTime,30 * Time.deltaTime));
    }
}
