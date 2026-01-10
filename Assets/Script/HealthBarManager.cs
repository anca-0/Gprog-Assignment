using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private HealthBar healthBarPrefab;

    void Start()
    {
        if(healthBarPrefab != null && health != null)
        {
            healthBarPrefab.SetHealth(health.GetCurrentHealth(), health.GetHealth());
        }
    }

    void Update()
    {
        if(healthBarPrefab != null && health != null)
        {
            healthBarPrefab.SetHealth(health.GetCurrentHealth(), health.GetHealth());
        }
    }
}
