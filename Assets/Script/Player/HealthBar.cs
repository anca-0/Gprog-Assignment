using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarImg;
    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (playerHealth != null && healthBarImg != null)
        {
           healthBarImg.fillAmount = playerHealth.GetCurrentHealth() / playerHealth.GetHealth();
        }
    }
}
