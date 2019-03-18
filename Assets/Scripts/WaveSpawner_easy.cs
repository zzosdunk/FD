using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner_easy : MonoBehaviour
{

    public static int enemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public int check;
    public Text waveCountdownText;

    private float countdown = 2f;
    private int waveIndex = 0;

    private bool isEnemySpawn = false;


    public GameManager gameManager;

    private void OnLevelWasLoaded()
    {
        enemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length )
        {

            gameManager.WinLevel();
            this.enabled = false;
            
            
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;

        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //checking the value cannot be less than 0

        waveCountdownText.text = string.Format("{0:00.00}", countdown); //format of countdown etc, 03.25 to next wave
    }
    IEnumerator SpawnWave()
    {

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)  //loop for amount of enemies
        {
            EnemySpawn(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        
        //waveIndex++;
        Debug.Log(waveIndex);
    }
    void EnemySpawn(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation); //creating a game object in the game
        isEnemySpawn = true;
    }
}
