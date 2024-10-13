using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector3(direction * _speed * Time.deltaTime, _rigidbody.velocity.y, 0);
    }

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
        {
            return TurnRight;
        }
        if (velocity.x < 0)
        {
            return TurnLeft;
        }

        return transform.rotation;
    }
}
