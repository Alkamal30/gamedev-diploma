using UnityEngine;

public class BowRotator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        Vector2 lookDirection = CalculateLookDirection();
        float angle = GetAngleByLookDirection(lookDirection);

        ControlSpriteFlip(lookDirection);
        SetBowAngle(angle);
    }

    private Vector2 CalculateLookDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - (Vector2) transform.position;

        return lookDirection.normalized;
    }

    private float GetAngleByLookDirection(Vector2 lookDirection)
    {
        return Vector2.SignedAngle(
            lookDirection.x >= 0f
                ? Vector2.right
                : Vector3.left,
            lookDirection
        );
    }

    private void ControlSpriteFlip(Vector2 lookDirection)
    {
        _spriteRenderer.flipX = lookDirection.x >= 0f ? false : true;
    }

    private void SetBowAngle(float angle)
    {
        Vector3 angles = transform.eulerAngles;
        angles.z = angle;
        transform.eulerAngles = angles;
    }
}
