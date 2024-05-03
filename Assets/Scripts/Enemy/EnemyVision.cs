using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distanceOfVisionPlayer = 3;
    [SerializeField] private float _distanceOfVisionObstacle = 1;
    [SerializeField] private float _distanceToLowerRay = 0.4f;

    private SpriteRenderer _spriteRenderer;
    private Transform _hitTransform;

    public event Action<Vector2> SeePlayer;
    public event Action SeeObstacle;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (TryToGetTransformThroughRay(transform.position, _distanceOfVisionPlayer, Color.yellow, out _hitTransform))
        {
            if (_hitTransform.TryGetComponent(out Player _))
                SeePlayer?.Invoke(_hitTransform.position);
        }

        Vector2 rayStartPosition = transform.position;
        rayStartPosition.y -= _distanceToLowerRay;

        if (TryToGetTransformThroughRay(rayStartPosition, _distanceOfVisionObstacle, Color.red, out _hitTransform))
        {
            if (_hitTransform.TryGetComponent(out Player _) == false)
                SeeObstacle?.Invoke();
        }
    }

    private bool TryToGetTransformThroughRay(Vector2 startPosition, float distanceOfVision, Color color, out Transform hitTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.right * CheckIfIsLookingRight(), distanceOfVision, _layerMask);
        Debug.DrawRay(startPosition, Vector2.right * CheckIfIsLookingRight() * distanceOfVision, color);
        hitTransform = null;
        bool result = false;

        if (hit)
        {
            hitTransform = hit.transform;
            result = true;
        }

        return result;
    }

    private int CheckIfIsLookingRight()
    {
        int lookingRight = 1;

        if (_spriteRenderer.flipX == true)
            lookingRight = -1;

        return lookingRight;
    }
}
