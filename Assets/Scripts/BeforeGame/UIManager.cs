using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Btn;
    private void Awake()
    {
       Btn.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(BtnActive());
    }

    IEnumerator BtnActive()
    {
        yield return new WaitForSeconds(4f);
        Btn.SetActive(true);
    }
}
