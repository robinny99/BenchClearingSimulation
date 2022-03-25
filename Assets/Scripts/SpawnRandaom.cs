using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRandaom : MonoBehaviour
{
    public bool enableSpawn = true;
    public GameObject EnemyGudge; //Prefab을 받을 public 변수 입니다.


    float distance;
    public GameObject Player;


    private void Update()
    {
        GetRandomPosition();
    }


    public Vector3 GetRandomPosition()
    {
        float radius = 30f;
        Vector3 playerPosition = Player.transform.position;
        float a = playerPosition.x;
        float b = playerPosition.z;
 
        float x = Random.Range(-radius + a, radius + a);
        float z_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
        z_b *= Random.Range(0, 2) == 0 ? -1 : 1;
        float z = z_b + b;
 
        Vector3 randomPosition = new Vector3(x, Player.transform.position.y, z);
 
        return randomPosition;
    }

    void SpawnEnemy()
    {
        //float randomX =
           // Random.Range(0.0f, 1.0f) * 10 * PlusOrNot() * Player.transform.position.x; //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        //float randomZ =
        //    Random.Range(0.0f, 1.0f) * 10 * PlusOrNot() * Player.transform.position.z;
        //if (enableSpawn)
        {
            GameObject enemy =
                (GameObject) Instantiate(EnemyGudge, GetRandomPosition(),
                    Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        }
        Debug.Log("JUDGE");
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 20f, 10); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
    }
}

