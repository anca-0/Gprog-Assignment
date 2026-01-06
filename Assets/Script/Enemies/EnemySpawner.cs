using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

   [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float spawnIntervat=3f;
    [SerializeField] private float maxEnemies=5;

    private float spawnTimer;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

  
    void Update()
    {
        //remove destroyed enemies from the list
        spawnedEnemies.RemoveAll(enemy => enemy == null);

        //only spawn if we are below the max enemy count
        if (spawnedEnemies.Count < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnIntervat)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }
    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }
    
}
