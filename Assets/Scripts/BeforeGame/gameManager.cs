using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public bool isMobile;
    private void Start()
    {
        FadeIn();
    }

    private void Update()
    {
        InGameStart();
    }
    
    //-------------------------------------------------------------------------------------------------------------------------------------------

    public void FadeOut()
    {
        StartCoroutine(FadeOutCo());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCo());
    }
    
    public void GameOver()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerMovement>().isDead)
            {
                FadeOut();
            }
        }
    }

    void InGameStart()
    {
        if (enemy != null)
        {
            if (enemy.GetComponent<EnemyController>().readyToRun)
            {
                GameStart();
            }
        }
    }

    public void GameStart() //게임이 시작 되었을 떄
    {
        LoadPauseB();
        LoadDistanceRecord();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("InGameBCS 2");
    }

    void LoadPauseB()
    {
        gameObject.GetComponent<PauseActive>().enabled = true;
    }

    void LoadDistanceRecord()
    {
        gameObject.GetComponent<RunningDistanceActive>().enabled = true;
    }

    IEnumerator FadeOutCo()
    {
        gameObject.GetComponent<Fade>().FadeOut();
        Debug.Log("FADEOUT START");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("InGameBCS 1");
    }
    

    IEnumerator FadeInCo()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Fade>().FadeIn();
    }
    
    
}
