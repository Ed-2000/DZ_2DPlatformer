using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Transform[] _waypoints;

    private int _targetWaypointIndex = 0;
    private float _minDistanceToWaypoint = 0.5f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        if (Vector2.SqrMagnitude(_waypoints[_targetWaypointIndex].position - transform.position) <= _minDistanceToWaypoint)
            _targetWaypointIndex = ++_targetWaypointIndex % _waypoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_targetWaypointIndex].position, _speed * Time.deltaTime);
    }

    void Flip()
    {
        if (transform.position.x < _waypoints[_targetWaypointIndex].position.x)
            _spriteRenderer.flipX = false;
        else if (transform.position.x > _waypoints[_targetWaypointIndex].position.x)
            _spriteRenderer.flipX = true;
    }
}
