using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _rayStartPosition;
    [SerializeField] private float _distanceOfVisionPlayer = 3;
    [SerializeField] private float _distanceOfVisionObstacle = 1;

    private float _maxDistanceOfVision = 0;
    private SpriteRenderer _spriteRenderer;
    private float _distanceOfVisionPlayerSquared;
    private float _distanceOfVisionObstacleSquared;

    public event Action<Vector2> SeePlayer;
    public event Action SeeObstacle;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _maxDistanceOfVision = Mathf.Max(_distanceOfVisionPlayer, _distanceOfVisionObstacle);
        _distanceOfVisionPlayerSquared = _distanceOfVisionPlayer * _distanceOfVisionPlayer;
        _distanceOfVisionObstacleSquared = _distanceOfVisionObstacle * _distanceOfVisionObstacle;
    }

    private void Update()
    {
        Vector3 rayStartPosition = transform.position + _rayStartPosition;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, Vector2.right * GetViewDirection(), _maxDistanceOfVision, _layerMask);
        Debug.DrawRay(rayStartPosition, Vector2.right * GetViewDirection() * _distanceOfVisionPlayer, Color.yellow);
        Debug.DrawRay(rayStartPosition, Vector2.right * GetViewDirection() * _distanceOfVisionObstacle, Color.red);

        if (hit)
        {
           Vector3 hitPoint = hit.point;
           float hitDistanceSquared = Vector2.SqrMagnitude(hitPoint - rayStartPosition);

            if (hit.transform.TryGetComponent(out Player _) && hitDistanceSquared <= _distanceOfVisionPlayerSquared)
                SeePlayer?.Invoke(hitPoint);
            else if (hitDistanceSquared <= _distanceOfVisionObstacleSquared)
                SeeObstacle?.Invoke();
        }
    }

    private int GetViewDirection()
    {
        int lookingRight = 1;

        if (_spriteRenderer.flipX == true)
            lookingRight = -1;

        return lookingRight;
    }
}
