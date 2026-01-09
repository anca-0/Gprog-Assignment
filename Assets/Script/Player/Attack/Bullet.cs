using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private int damage = 10;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (collision.CompareTag("walls"))
        {
            Destroy(gameObject);
        }
    }
}
