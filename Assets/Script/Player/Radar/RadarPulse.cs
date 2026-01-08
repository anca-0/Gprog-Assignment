using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RadarPulse : MonoBehaviour
{
    [SerializeField] private Transform RadarPing;
    private Transform pulseTransform;
    private float range;
    private float rangeMax;
    private List<Collider2D> AlreadyDetectedCollider;
    private bool isPulsing = false;


    private void Awake()
    {
        pulseTransform = transform.Find("Pulse");
        rangeMax = 3f;
        AlreadyDetectedCollider = new List<Collider2D>();

        StartPulse();
    }
    private void Update()
    {
        if (isPulsing)
        {
            UpdatePulse();
        }
    }
    private void StartPulse()
    {
        isPulsing = true;
        range = 0f;
        AlreadyDetectedCollider.Clear();

        if (pulseTransform!=null) pulseTransform.gameObject.SetActive(true);
    }

    private void UpdatePulse()
    {
        float rangespeed= 2f;
        range += rangespeed * Time.deltaTime;
        if (range > rangeMax)
        {
            range = 0f;
            isPulsing = false;
            AlreadyDetectedCollider.Clear();
            if (pulseTransform != null)
            {
                pulseTransform.gameObject.SetActive(false);
            }
            return;
        }
        pulseTransform.localScale = new Vector3(range, range);

        // Identify owner (e.g. the player) so we can ignore its colliders
        GameObject owner = transform.root.gameObject;

        RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, range*2f, Vector2.zero);
        foreach (RaycastHit2D raycastHit2D in raycastHit2DArray)
        {

            if (raycastHit2D.collider != null)
            {
                // Ignore collisions with the owner (root) or any of its children, or objects tagged "Player"
                if (raycastHit2D.collider.gameObject == owner || raycastHit2D.collider.transform.IsChildOf(owner.transform) || raycastHit2D.collider.CompareTag("Player"))
                    continue;
                if ( raycastHit2D.collider.CompareTag("walls"))
                    continue;

                if (!AlreadyDetectedCollider.Contains(raycastHit2D.collider))
                {
                    AlreadyDetectedCollider.Add(raycastHit2D.collider);

                    Vector2 pingPosition = raycastHit2D.point;

                    Transform radarPingTransform = Instantiate(RadarPing, raycastHit2D.point, Quaternion.identity);
                    RadarPing radarPing = radarPingTransform.GetComponent<RadarPing>();
                    if (raycastHit2D.collider.gameObject.GetComponent<EnemyAI>() != null) 
                    {
                        radarPing.SetColor(new Color(1, 0, 0));
                        if(raycastHit2D.collider.TryGetComponent<EnemyInvestigation>(out var investigation))
                        {
                            Vector2 playerPosition = transform.position;
                            investigation.AddInvestigationPoint(playerPosition);
                        }

                    }
                    //Debug.Log("Hit: " + raycastHit2D.collider.name);
                }
            }
        }

    }
    

}
