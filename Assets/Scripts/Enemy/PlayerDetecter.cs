using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class PlayerDetecter : MonoBehaviour
{
    [SerializeField] private Transform _groundDetektorPoint;
    [SerializeField] private float _rayLenght;
    [SerializeField] private LayerMask _maskPlayer;

    private float _speed = 1.0f;

    public bool IsFound {  get; private set; } = false;
    public Transform Target {  get; private set; }


    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            IsFound = true;
            Target = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            IsFound = false;
        }
    }

    public bool CheakSidePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundDetektorPoint.position, Vector2.left, _rayLenght, _maskPlayer);

        return hit.collider;
    }
}
