using UnityEngine;
using System.Collections.Generic;

public class EnemyInvestigation : MonoBehaviour
{
    private float waypointReachedDist = 0.5f;
    private float investigateDelay = 1f;

    private Queue<Vector2> investigateQ = new Queue<Vector2>();
    private EnemyPathfinding pathfinding;
    private EnemyAI enemyAI;
    private Vector2? currentInvestigTarget;
    private float delayTimer;

    private void Awake()
    {
        pathfinding = GetComponent<EnemyPathfinding>();
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if (enemyAI != null && enemyAI.GetCurrentState() == "Chasing") return;
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            pathfinding.StopMoving();
            return;
        }
        if (currentInvestigTarget.HasValue) 
        {
            pathfinding.MoveTo(currentInvestigTarget.Value);
            float distance = Vector2.Distance(transform.position, currentInvestigTarget.Value);
            if (distance <= waypointReachedDist)
            {
                ReachedInvestigationPoint();
            }
        }
        else if (investigateQ.Count > 0)
        {
            currentInvestigTarget = investigateQ.Dequeue();
            //Debug.Log(gameObject.name + "dequeued position" + currentInvestigTarget.Value + ". Queue remaining:" investigateQ.Count);
        }
    }

    public void AddInvestigationPoint(Vector2 playerPos)
    {
        investigateQ.Enqueue(playerPos);
        //Debug.Log(gameObject.name + " added investigation point at " + playerPos + ". Total in queue: " + investigateQ.Count);
    }
    public void ReceivePingLoc(List<Vector2> pingLocations)
    {
        foreach (Vector2 pingPos in pingLocations) investigateQ.Enqueue(pingPos);
        //Debug.Log(gameObject.name + " received " + pingLocations.Count + " pings. Total in queue: " + investigateQ.Count);
    }

    private void ReachedInvestigationPoint()
    {
        currentInvestigTarget = null;
        delayTimer = investigateDelay;
    }

    public bool IsInvestigating()
    {
        return currentInvestigTarget.HasValue || investigateQ.Count > 0;
    }

    public void ClearInvestigations()
    {
        investigateQ.Clear();
        currentInvestigTarget = null;
    }

}
