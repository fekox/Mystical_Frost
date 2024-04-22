using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManeger : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerJump playerJump;

    public void OnMove(InputValue value)
    {
        playerMovement.Move(value);
    }

    public void OnJump() 
    {
        playerJump.JumpLogic();
    }
}
