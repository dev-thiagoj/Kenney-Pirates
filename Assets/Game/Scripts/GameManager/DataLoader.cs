using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    [Header("Game Session Time")]
    [SerializeField] GameSessionManager gameSessionManager;
    [SerializeField] Slider timeSessionSlider;

    [Header("Enemy Spawn Time")]
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Slider spawnerSlider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SessionTime"))
        {
            int localValue = PlayerPrefs.GetInt("SessionTime");

            timeSessionSlider.value = localValue;
            gameSessionManager.sessionTime = localValue;
        }
        else
        {
            timeSessionSlider.value = 2;
            gameSessionManager.sessionTime = 2;
        }

        if (PlayerPrefs.HasKey("EnemySpawnTime"))
        {
            int localValue = PlayerPrefs.GetInt("EnemySpawnTime");

            spawnerSlider.value = localValue;
            enemySpawner.spawnTime = localValue;
        }
        else
        {
            spawnerSlider.value = 10;
            enemySpawner.spawnTime = 10;
        }
    }
}
