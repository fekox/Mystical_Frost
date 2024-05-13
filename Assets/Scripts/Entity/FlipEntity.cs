using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEntity : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private GameObject shootPivot;

    Quaternion currentRotation;

    private bool lookRight = true;
    public void FlipLogic() 
    {
        if (playerMovement.movementDirection > 0 && !lookRight) 
        {
            currentRotation.y = 0f;
            Flip(currentRotation);
        }

        if (playerMovement.movementDirection < 0 && lookRight) 
        {
            currentRotation.y = 180f;
            Flip(currentRotation);
        }
    }

    private void Flip(Quaternion currentRotation) 
    {
        int aux = -1;

        Vector3 currentScale = transform.localScale;
        
        currentScale.x *= aux;

        shootPivot.transform.rotation = currentRotation;
        transform.localScale = currentScale;

        lookRight = !lookRight; 
    }
}
