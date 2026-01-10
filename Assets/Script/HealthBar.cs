using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Color full = Color.green;
    public Color low = Color.red;
    public Vector3 offset = new Vector3(0, 2, 0);

    private Image fillImage;
    void Start()
    {
        fillImage = slider.fillRect.GetComponent<Image>();
    }

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
        if (fillImage != null)
        {
            float healthPrecent = health / maxHealth;
            fillImage.color = Color.Lerp(low, full, healthPrecent);
        }
    }
}