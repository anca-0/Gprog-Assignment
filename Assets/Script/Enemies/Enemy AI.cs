using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{

    private enum State
    {
        None,
        Roaming,
        Chasing
    }

    private State state;
    private EnemyPathfinding enemyPathFinding;
    private Coroutine currentRoutine;

    public Transform player;
    public float chaseRange = 3f;
    public float stopChaseRange = 5f;
   
    public float roamRadius = 5f;

    private EnemyInvestigation investigation;

    private void Awake()
    {
        enemyPathFinding = GetComponent<EnemyPathfinding>();
        investigation = GetComponent<EnemyInvestigation>();

        if (player == null)
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            if (go != null) player = go.transform;
        }
    }

    private void Start()
    {
        SetState(State.Roaming);
    }

    private void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance((Vector2)transform.position, (Vector2)player.position);

        if (state != State.Chasing && dist <= chaseRange)
        {
            if (investigation != null) investigation.ClearInvestigations();
            SetState(State.Chasing);
        }
        else if (state == State.Chasing && dist > stopChaseRange)
        {
            SetState(State.Roaming);
        }
    }

    private void SetState(State newState)
    {
        
        if (newState == state) return;

        

        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
            currentRoutine = null;
        }

        state = newState;

        switch (state)
        {
            case State.Roaming:
                currentRoutine = StartCoroutine(RoamingRoutine());
                break;
            case State.Chasing:
                currentRoutine = StartCoroutine(ChasingRoutine());
                break;
        }
    }

    private IEnumerator RoamingRoutine()
    {
       

        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPosition);

            yield return new WaitForSeconds(4f);
        }
    }

    private IEnumerator ChasingRoutine()
    {
        while (state == State.Chasing)
        {
            if (player != null)
            {
                enemyPathFinding.MoveTo((Vector2)player.position);
            }
            yield return null;
        }
    }

    private Vector2 GetRoamingPosition()
    {
        
        Vector2 randomOffset = Random.insideUnitCircle * roamRadius;
        return (Vector2)transform.position + randomOffset;
    }
    public string GetCurrentState()
    {
        return state.ToString();
    }

}