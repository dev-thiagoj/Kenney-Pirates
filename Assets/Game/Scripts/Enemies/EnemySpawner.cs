using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesList;
    [SerializeField] List<Transform> spawnPositions;
    [SerializeField] float spawnTime;

    private void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    [NaughtyAttributes.Button]
    void SpawnEnemy()
    {
        int index = Random.Range(0, enemiesList.Count - 1);
        GameObject ship = Instantiate(enemiesList[index]);
        ship.transform.parent = GameObject.Find("=== ENEMIES ===").GetComponent<Transform>();

        int pos = Random.Range(0, spawnPositions.Count - 1);
        ship.transform.position = spawnPositions[pos].position;
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            int index = Random.Range(0, enemiesList.Count - 1);
            GameObject ship = Instantiate(enemiesList[index]);
            ship.transform.parent = GameObject.Find("=== ENEMIES ===").GetComponent<Transform>();

            int pos = Random.Range(0, spawnPositions.Count - 1);
            ship.transform.position = spawnPositions[pos].position;

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
