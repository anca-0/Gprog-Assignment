using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private int maxCoins = 6;
    private Vector2 spawnAreaMin = new Vector2(-20, -20);
    private Vector2 spawnAreaMax = new Vector2(20, 20);
    [SerializeField] private LayerMask wallLayer;
    private float coinRadius = 0.5f;
    private int maxAttempts = 30;
    private float spawnCheckInterval = 0.5f;

    private float nextCheckTime = 0f;

    private void Update()
    {
        if (Time.time >= nextCheckTime)
        {
            MaintainCoinCount();
            nextCheckTime = Time.time + spawnCheckInterval;
        }
    }

    private void MaintainCoinCount()
    {
        int currentCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        int coinsToSpawn = maxCoins - currentCoins;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        int attempts = 0;
        bool spawned = false;

        while (attempts < maxAttempts && !spawned)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );


            Collider2D hitCollider = Physics2D.OverlapCircle(randomPosition, coinRadius, wallLayer);

            if (hitCollider == null)
            {
                Instantiate(coinPrefab, randomPosition, Quaternion.identity);
                spawned = true;
            }

            attempts++;
        }
    }
}
