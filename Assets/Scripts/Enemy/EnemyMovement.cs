using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyRenderer), typeof(EnemyVision))]
public class EnemyMovement : HumanoidMovement
{
    [SerializeField] private float _timeBetweenJumps = 0.25f;
    [SerializeField] private Transform[] _waypoints;

    private EnemyRenderer _enemyRenderer;
    private EnemyVision _enemyVision;
    private Vector3 _targetWaypoinPosition;
    private int _targetWaypointIndex = 0;
    private bool _isSeePlayer = false;
    private float _minDistanceToWaypoint = 0.5f;
    private float _timePassedBetweenJumps = 0.1f;

    private void Awake()
    {
        _enemyRenderer = GetComponent<EnemyRenderer>();
        _enemyVision = GetComponent<EnemyVision>();
        Rigidbody = GetComponent<Rigidbody2D>();

        _targetWaypoinPosition = _waypoints[_targetWaypointIndex].position;
    }
    private void OnEnable()
    {
        _enemyVision.SeePlayer += PlayerVisibilityHandler;
        _enemyVision.SeeObstacle += ObstacleVisibilityHandler;
    }

    private void OnDisable()
    {
        _enemyVision.SeePlayer -= PlayerVisibilityHandler;
        _enemyVision.SeeObstacle -= ObstacleVisibilityHandler;
    }

    private void Update()
    {
        _timePassedBetweenJumps += Time.deltaTime;

        SetTargetWaypoint();
        MoveTo(_targetWaypoinPosition);
    }

    private void FixedUpdate()
    {
        if (IsNeedToJump == true)
        {
            IsNeedToJump = false;
            Jump();
        }
    }

    private void PlayerVisibilityHandler(Vector2 target)
    {
        _targetWaypoinPosition = target;
        _isSeePlayer = true;
    }

    private void ObstacleVisibilityHandler()
    {
        if (_timePassedBetweenJumps >= _timeBetweenJumps)
        {
            _timePassedBetweenJumps = 0;
            IsNeedToJump = true;
        }
    }

    private void SetTargetWaypoint()
    {
        if (Vector2.SqrMagnitude(_targetWaypoinPosition - transform.position) <= _minDistanceToWaypoint)
        {
            if (_isSeePlayer == false)
            {
                _targetWaypointIndex = ++_targetWaypointIndex % _waypoints.Length;
                _targetWaypoinPosition = _waypoints[_targetWaypointIndex].position;
            }

            _isSeePlayer = false;
        }
    }

    private void MoveTo(Vector3 target)
    {
        _enemyRenderer.Flip(target.x);
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
