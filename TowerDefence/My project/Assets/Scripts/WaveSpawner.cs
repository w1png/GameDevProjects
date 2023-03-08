using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timeToNextWave;

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float waitBetweenSpawn = 0.5f;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Update()
    {
        UpdateUI();

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waitBetweenSpawn);
        }
    }

    void UpdateUI()
    {
        waveText.text = "Wave: " + waveIndex.ToString();

        float countdown_floored = Mathf.Floor(countdown);
        string countdown_text = countdown_floored == 0f ? "Now" : countdown_floored.ToString() + "s";
        timeToNextWave.text = "Next wave in: " + countdown_text;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    
}
