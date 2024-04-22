using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float movementDirection;
    private Rigidbody rigidBody;

    public float speed = 3.0f;

    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        movementDirection = 0;
    }

    public void Move(InputValue value) 
    {
        var movementInput = value.Get<Vector2>();

        movementDirection = movementInput.x;
    }

    public void MoveLogic() 
    {
        rigidBody.velocity = new Vector3(movementDirection * speed, rigidBody.velocity.y, 0);
    }
}
