using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

   [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private float timeUntilNextSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn() 
    {
        timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

    }
}
