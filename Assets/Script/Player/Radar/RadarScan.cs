using UnityEngine;

public class RadarScan : MonoBehaviour
{
    private float scanRadius = 10f;
    private KeyCode scanKey = KeyCode.Space;

    private LayerMask enemyLayer;
    private LayerMask obstacleLayer;

   
    public void ScanForEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, scanRadius, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            Transform enemy = hit.transform;
            Vector2 direction = enemy.position - transform.position;
            float distance = Vector2.Distance(transform.position, enemy.position);

            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction.normalized, distance, obstacleLayer);
            if (ray.collider == null)
            {
                Debug.Log("Enemy detected: " + enemy.name);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }

}
