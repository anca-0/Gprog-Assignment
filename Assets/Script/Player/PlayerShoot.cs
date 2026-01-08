using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float blltspeed;
    [SerializeField] private Transform firePoint;

    private void OnFire (InputValue inputValue)
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mousePos.z = 0;

        // Calculate direction from player to mouse
        Vector2 direction = (mousePos - transform.position).normalized;

        // Instantiate bullet at fire point (or player position)
        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
        GameObject spawnedBullet = Instantiate(bullet, spawnPos, Quaternion.identity);

        // Get the Rigidbody2D and set velocity
        Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * blltspeed;
        }
    }

}
