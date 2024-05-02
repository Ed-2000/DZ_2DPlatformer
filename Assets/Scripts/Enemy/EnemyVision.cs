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

    public event Action<Vector2> SeePlayer;
    public event Action SeeObstacle;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (TryToGetTransformThroughRay(transform.position, Vector2.right * CheckIfIsLookingRight(), _distanceOfVisionPlayer, _layerMask, Color.yellow, out Transform hitTransform))
        {
            if (hitTransform.TryGetComponent(out Player _))
                SeePlayer?.Invoke(hitTransform.position);
        }

        Vector2 rayStartPosition = transform.position;
        rayStartPosition.y -= _distanceToLowerRay;

        if (TryToGetTransformThroughRay(rayStartPosition, Vector2.right * CheckIfIsLookingRight(), _distanceOfVisionObstacle, _layerMask, Color.red, out hitTransform))
        {
            if (hitTransform.TryGetComponent(out Player _) == false)
                SeeObstacle?.Invoke();
        }
    }

    private bool TryToGetTransformThroughRay(Vector2 startPosition, Vector2 direction, float distanceOfVision, LayerMask layerMask, Color color, out Transform hitTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, distanceOfVision, layerMask);
        Debug.DrawRay(startPosition, direction * distanceOfVision, color);
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
