using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject SpawnJudge;
    public bool isMobile;
    private void Start()
    {
        FadeIn();
        SpawnJudgeOff();
    }

    private void Update()
    {
        InGameStart();

        InGameEnd();
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

    public void InGameEnd()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerMovement>().isDead)
            {
                JoysticOff();
                SpawnJudgeOff();
            }   
        }
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

    void JoysticOff()
    {
        gameObject.GetComponent<JoystickOnOff>().JoystickOff();
        Debug.Log("GAME OVER");
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
        
        gameObject.GetComponent<JoystickOnOff>().JoystickOn();
        
        SpawnJudgeOn();
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
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("InGameBCS 1");
    }
    

    IEnumerator FadeInCo()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Fade>().FadeIn();
    }

    void SpawnJudgeOn()
    {
        SpawnJudge.GetComponent<SpawnRandaom>().enabled  = true;
        Debug.Log("Spawn Judge");
    }
    
    void SpawnJudgeOff()
    {
        SpawnJudge.GetComponent<SpawnRandaom>().enabled = false;
        Debug.Log("Spawn Judge.Fin");
    }
}
