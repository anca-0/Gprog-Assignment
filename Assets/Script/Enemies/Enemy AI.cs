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

    [Header("Chase Settings")]
    public Transform player;
    public float chaseRange = 3f;
    public float stopChaseRange = 5f;

    [Header("Roam Settings")]
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
        //Debug.Log($"Enemy {gameObject.name}: Player found = {player != null}");
    }

    private void Start()
    {
       // Debug.Log($"Enemy {gameObject.name}: Starting roaming");
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
        //Debug.Log($"Enemy {gameObject.name}: SetState called with {newState}, current state is {state}");
        if (newState == state) return;

        //Debug.Log($"Enemy {gameObject.name}: Actually changing state to {newState}");


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
        //Debug.Log($"Enemy {gameObject.name}: RoamingRoutine started");

        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            Debug.Log($"Enemy {gameObject.name}: Moving to {roamPosition}");
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
        // Pick a random point within a circle around the enemy's current position.
        // Using world coordinates avoids all enemies targeting the same unit circle around the origin.
        Vector2 randomOffset = Random.insideUnitCircle * roamRadius;
        return (Vector2)transform.position + randomOffset;
    }
    public string GetCurrentState()
    {
        return state.ToString();
    }

}