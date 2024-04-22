using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] public Transform firePoint;

    [SerializeField] public GameObject bulletPrefab;

    public void ShootLogic() 
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
