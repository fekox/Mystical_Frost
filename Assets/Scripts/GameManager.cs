using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerJump playerJump;

    private void FixedUpdate()
    {
        playerMovement.MoveLogic();
    }
}
