using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _distance;

    public bool CantPass() => IsWall(_distance, _mask);

    public bool IsWall(float distance, LayerMask mask) => Physics2D.Raycast(transform.position, Vector2.left, distance, mask);

    public bool IsGround() => Physics2D.Raycast(transform.position, Vector2.down, _distance, _mask);
}
