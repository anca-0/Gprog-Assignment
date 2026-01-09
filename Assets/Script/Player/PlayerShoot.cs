using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Transform firePoint; 
    [SerializeField] private float fireRate = 0.5f;

    private PlayerControls playerControls;
    private float nextFireTime;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Movement.Fire.performed += _ => Shoot();
    }

    private void OnDisable()
    {
        playerControls.Movement.Fire.performed -= _ => Shoot();
        playerControls.Disable();
    }

    private void Shoot()
    {
        if(Time.time< nextFireTime)
        {
            return;
        }
        nextFireTime = Time.time + fireRate;
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0));

        Vector2 direction = (mousePos - transform.position).normalized;
        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }


    }

}
