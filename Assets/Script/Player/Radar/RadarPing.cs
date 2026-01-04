using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadarPing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float disappearTime;
    private float disappearTimeMax;
    private Color color;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        disappearTime = 0f;
        disappearTimeMax = 1f;
        color = new Color(1, 1, 1, 1f);
    }

    private void Update() {
        disappearTime += Time.deltaTime;
        color.a = Mathf.Lerp(disappearTimeMax, 0f, disappearTime / disappearTimeMax);
        spriteRenderer.color = color;

        if (disappearTime >= disappearTimeMax)
        {
            Destroy(gameObject);
        }
    
    }
    public void SetColor(Color color)
    {
        this.color = color;
    }

    public void SetDisappearTime(float disappearTimeMax) { 
        this.disappearTimeMax = disappearTimeMax;
        disappearTime = 0f;
    }
}
