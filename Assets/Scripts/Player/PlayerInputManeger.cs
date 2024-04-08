using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManeger : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    public void OnMove(InputValue value)
    {
        playerMovement.Move(value);
    }
}
