    using UnityEngine;

public class GroundChecker1 : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _maskGround;
    [SerializeField] Transform _groundDetecter;

    private float _distance = 0;
    private CapsuleCollider2D _collider;

    public bool IsGround()
    {
        return Physics2D.CircleCast(_point.position, _radius, Vector2.down, _distance, _maskGround);
    }

    public bool CheckGround()
    {
        //RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetecter.position, Vector2.down, 1f);
        RaycastHit2D hit = Physics2D.Raycast(_groundDetecter.position, Vector2.down, 1f, _maskGround);

        return hit.collider;
    }
}
