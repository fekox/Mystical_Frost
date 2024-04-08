using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private const int maxFloorDistance = 10;

    [Header("Setup")]

    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform feetPivot;


    [Header("Movement")]

    [SerializeField] private float jumpForce = 6f;

    [SerializeField] private float minJumpDistance = 0.25f;

    [SerializeField] private float jumpBufferTime = 0.25f;

    [SerializeField] private float coyoteTime = 0.2f;

    [SerializeField] private float maxJumpAnimation = 0.5f;

    private float maxJumpForce;
    private float normalJumpForce;

    private Coroutine _jumpCoroutine;

    private float jumpAnimationTimer;

    [Header("References")]

    [SerializeField] private PlayerMovement playerMovement;

    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    void Start()
    {
        int auxNumber = 3;

        normalJumpForce = jumpForce;
        maxJumpForce = jumpForce * auxNumber;

        if (!rigidBody)
        {
            enabled = false;
        }

        jumpAnimationTimer = maxJumpAnimation;
    }

    public void JumpLogic()
    {
        if (_jumpCoroutine != null)
        {
            StopCoroutine(_jumpCoroutine);
        }

        _jumpCoroutine = StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        float lineDuration = 5f;

        if (!feetPivot)
        {
            yield break;
        }

        for (var timeElapsed = 0.0f; timeElapsed <= jumpBufferTime; timeElapsed += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();

            var isFalling = rigidBody.velocity.y <= 0;
            var currentFeetPosition = feetPivot.position;

            var canNormalJump = isFalling && CanJumpInPosition(currentFeetPosition);

            var coyoteTimeFeetPosition = currentFeetPosition - rigidBody.velocity * coyoteTime;
            var canCoyoteJump = isFalling && CanJumpInPosition(coyoteTimeFeetPosition);

            if (!canNormalJump && canCoyoteJump)
            {
                Debug.DrawLine(currentFeetPosition, coyoteTimeFeetPosition, Color.green, lineDuration);
            }

            if (canNormalJump || canCoyoteJump)
            {
                var jumpForceVector = Vector3.up * jumpForce;

                if (rigidBody.velocity.y < 0)
                    jumpForceVector.y -= rigidBody.velocity.y;

                rigidBody.AddForce(jumpForceVector, ForceMode.Impulse);

                yield break;
            }
        }
    }

    private bool CanJumpInPosition(Vector3 currentFeetPosition)
    {
        return Physics.Raycast(currentFeetPosition, Vector3.down, out var hit, maxFloorDistance)
               && hit.distance <= minJumpDistance;
    }

    private void OnDrawGizmosSelected()
    {
        if (!feetPivot)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(feetPivot.position, feetPivot.position + Vector3.down * minJumpDistance);
    }
}
