using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [ SerializeField] private float damageAmount = 10f;
    [ SerializeField] private string targetTag;
    [ SerializeField] private bool destroyOnHit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Health targetHealth = other.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damageAmount);
                Debug.Log($"{gameObject.name} dealt {damageAmount} damage to {other.gameObject.name}");
                if (destroyOnHit)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
