using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class RadarPulse : MonoBehaviour
{
    private Transform pulseTransform;
    private float range;
    private float rangeMax;
    private List<Collider2D> AlreadyDetectedCollider;

    private void Awake()
    {
        pulseTransform = transform.Find("Pulse");
        rangeMax = 2f;
        AlreadyDetectedCollider = new List<Collider2D>();
    }
    private void Update()
    {
        float rangespeed= 1f;
        range += rangespeed * Time.deltaTime;
        if (range >= rangeMax)
        {
            range = 0f;
            AlreadyDetectedCollider.Clear();
        }
        pulseTransform.localScale = new Vector3(range, range);

        RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, range/2f, Vector2.zero);
        foreach (RaycastHit2D raycastHit2D in raycastHit2DArray)
        {

            if (raycastHit2D.collider != null)
            {
                if (!AlreadyDetectedCollider.Contains(raycastHit2D.collider))
                {
                    AlreadyDetectedCollider.Add(raycastHit2D.collider);
                    Debug.Log("Hit: " + raycastHit2D.collider.name);
                }
            }
        }

    }
    
}
