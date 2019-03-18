using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int enemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    public Transform spawnPoint2;

    public float timeBetweenWaves = 5f;

    public Text waveCountdownText;

    private float countdown = 2f;
    private int waveIndex = 0;
    private int waveIndex2 = 0;

    private bool isEnemySpawn = false;
    private bool isEnemySpawn2 = false;

    public GameManager gameManager;

    private void OnLevelWasLoaded()
    {
        enemiesAlive = 0;
    }

    // Update is called once per frame
    void Update () {

        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length && waveIndex2 == waves.Length)
        {
                gameManager.WinLevel();
                this.enabled = false;
        }

        if (countdown <= 0f )
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;

        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //checking the value cannot be less than 0

        waveCountdownText.text = string.Format("{0:00.00}", countdown); //format of countdown etc, 03.25 to next wave
	}
    //public static IEnumerator WaitForRealSeconds(float time)
    //{
    //    float start = Time.realtimeSinceStartup;
    //    while (Time.realtimeSinceStartup < start + time)
    //    {
    //        yield return null;
    //    }
    //}

    IEnumerator SpawnWave()
    {

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        Debug.Log(wave);
        enemiesAlive = wave.count + wave.secoundCount;

        for (int i = 0; i < wave.count; i++)  //loop for amount of enemies
        {
            EnemySpawn(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        for (int i = 0; i < wave.secoundCount; i++)  //loop for amount of enemies
        {
            EnemySpawn2(wave.anotherEnemy);
            yield return new WaitForSeconds(1f / wave.secondRate);
        }
        waveIndex2++;
        //waveIndex++;
        Debug.Log(waveIndex);
    }
    void EnemySpawn(GameObject enemy)
    {
        

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation); //creating a game object in the game
        
        isEnemySpawn = true;
    }
    void EnemySpawn2(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
        isEnemySpawn2 = true;
    }
}
