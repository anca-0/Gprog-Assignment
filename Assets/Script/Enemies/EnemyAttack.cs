using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   private float damageAmount = 10f;
    private float damageInterval = 1f;

    private float nextDamageTime = 0f;

   private void OnCollisionEnter2D(Collision2D collision)
   {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Time.time>= nextDamageTime)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("Dealing damage to player!");
                playerHealth.TakeDamage(damageAmount);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
