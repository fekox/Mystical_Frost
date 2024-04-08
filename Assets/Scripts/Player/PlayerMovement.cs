using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementDirection;
    private Rigidbody rigidBody;

    public float speed = 3.0f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        movementDirection = new Vector2(0.0f, 0.0f);
    }

    public void Move(InputValue value) 
    {
        var movementInput = value.Get<Vector2>();

        movementDirection = new Vector2(movementInput.x, movementInput.y).normalized;
    }

    public void MoveLogic() 
    {
        rigidBody.velocity = new Vector2(movementDirection.x * speed, movementDirection.y * speed);
    }
}
