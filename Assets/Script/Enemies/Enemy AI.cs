using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        //Chasing
    }
    //private float detectionRadius = 5f;
    //private float roamChangeTime = 2f;
    private State state;
    private EnemyPathfinding enemyPathFinding;

    private void Awake()
    {
        enemyPathFinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);

        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)).normalized;
    }
}
