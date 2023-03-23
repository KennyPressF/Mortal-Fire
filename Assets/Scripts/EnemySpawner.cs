using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]  List<Transform> spawnerList;
    [SerializeField] GameObject[] enemyArray;

    [SerializeField] float spawnTimer;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] int wave;
    [SerializeField] bool canSpawn;

    Timer timer;
    PlayerXP playerXP;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        playerXP = FindObjectOfType<PlayerXP>();

        foreach(Transform child in transform)
        {
            spawnerList.Add(child);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        IncreaseWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.keepTime == true)
        {
            spawnTimer -= Time.deltaTime;
        }

        if(spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = timeBetweenSpawns;
        }
    }

    public void IncreaseWave()
    {
        wave = playerXP.GetCurrentLevel();
        timeBetweenSpawns -= 0.05f;
    }

    private void SpawnEnemy()
    {
        int maxWave;
        if (wave > enemyArray.Length)
        {
            maxWave = enemyArray.Length;
        }
        else
        {
            maxWave = wave;
        }

        int randomEnemyIndex = Random.Range(0, maxWave);
        GameObject enemyToSpawn = enemyArray[randomEnemyIndex];

        int randomSpawnerIndex = Random.Range(0, spawnerList.Count);
        Transform selectedSpawner = spawnerList[randomSpawnerIndex];

        Instantiate(enemyToSpawn, selectedSpawner);
    }
}
