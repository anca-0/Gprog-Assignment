using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector2 direction;
    private Rigidbody2D rb;
    private bool isMoving = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(isMoving && direction!= Vector2.zero)
        {
            rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
        }
    }
    public void MoveTo(Vector2 targetPosition)
    {
        Vector2 currentPosition = transform.position;
        direction = (targetPosition - currentPosition).normalized;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        direction = Vector2.zero;
    }
}
