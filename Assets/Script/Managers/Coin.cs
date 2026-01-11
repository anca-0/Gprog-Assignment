using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coinValue = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}
