using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Renamed to avoid confusion
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Transform firePoint; // Optional: spawn point for bullets
    [SerializeField] private float fireRate = 0.1f; // Time between shots

    private bool fireContinuous;
    private float nextFireTime;

    void Update()
    {
        if (fireContinuous && Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireBullet()
    {
        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Calculate direction from player to mouse
        Vector2 direction = (mousePos - transform.position).normalized;

        // Spawn position
        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;

        // Instantiate bullet with correct rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject spawnedBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0, 0, angle));

        // Set bullet velocity
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }

    private void OnAttack(InputValue value)
    {
        fireContinuous = value.isPressed;
    }

}
