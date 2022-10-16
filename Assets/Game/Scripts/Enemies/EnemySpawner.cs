using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    [SerializeField] List<GameObject> enemiesList;
    [SerializeField] List<SpawnCheckPlayerPosition> spawnPositions;

    #region Actions
    private void OnEnable()
    {
        Actions.playerDied += StopCoroutine;
    }

    private void OnDisable()
    {
        Actions.playerDied -= StopCoroutine;
    }
    #endregion

    private void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            int pos = Random.Range(0, spawnPositions.Count - 1);
            bool freePos = spawnPositions[pos].GetComponent<SpawnCheckPlayerPosition>().canSpawn;

            if (freePos)
            {
                int index = Random.Range(0, enemiesList.Count - 1);
                GameObject ship = Instantiate(enemiesList[index]);
                ship.transform.parent = GameObject.Find("=== ENEMIES ===").GetComponent<Transform>();
                ship.transform.position = spawnPositions[pos].transform.position;
                yield return new WaitForSeconds(spawnTime);
            }
            else 
                yield return new WaitForEndOfFrame();
        }
    }

    void StopCoroutine()
    {
        StopCoroutine(SpawnEnemyCoroutine());
    }
}
