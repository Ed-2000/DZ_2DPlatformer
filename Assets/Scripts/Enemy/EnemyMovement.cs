using UnityEngine;

[RequireComponent(typeof(EnemyRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 3f;

    private EnemyRenderer _enemyRebderer;
    private int _targetWaypointIndex = 0;
    private float _minDistanceToWaypoint = 0.5f;

    private void Awake()
    {
        _enemyRebderer = GetComponent<EnemyRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetWaypoinPosition = _waypoints[_targetWaypointIndex].position;

        if (Vector2.SqrMagnitude(targetWaypoinPosition - transform.position) <= _minDistanceToWaypoint)
            _targetWaypointIndex = ++_targetWaypointIndex % _waypoints.Length;

        _enemyRebderer.Flip(targetWaypoinPosition.x);
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_targetWaypointIndex].position, _speed * Time.deltaTime);
    }
}
