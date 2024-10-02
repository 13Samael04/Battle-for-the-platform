using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class cube : MonoBehaviour
{
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if ((characterController.collisionFlags) != 0)
        {
            print("touched the ceiling");
        }
        if (characterController.isGrounded)
        {
            print("CharacterController is grounded");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((characterController.collisionFlags) != 0)
        {
            print("touched the ceiling");
        }
        if (characterController.isGrounded)
        {
            print("CharacterController is grounded");
        }
    }
}
